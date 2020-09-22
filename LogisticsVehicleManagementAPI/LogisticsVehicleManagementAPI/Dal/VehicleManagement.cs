using LogisticsVehicleManagementAPI.Models;
﻿using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Linq;

using System.Net.Http.Headers;
using System.Threading;


namespace Dal
{
    public class VehicleManagement : IVehicleManagement
    {

        SqlSugarClient db = new SqlSugarClient(
            new ConnectionConfig
            {
                ConnectionString = "server=DESKTOP-HNEDNFK;uid=sa;pwd=1234321;database=VehicleManagementSystem",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,


                //InitKeyType = InitKeyType.Attribute
            });

       

              


        //显示车辆
        public List<VehicleManage> Show(string name="")

        {

            List<VehicleManage> list = db.Queryable<VehicleManage>().ToList();
            list = list.Where(m => m.Status == false).ToList();
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(m => m.Licenseplatenumber.Contains(name)).ToList();
               
            }
            return list;
        }

        //添加车辆
        public int AddCar([FromForm]VehicleManage m)
        {




            var sql = new VehicleManage() { Licenseplatenumber = m.Licenseplatenumber, ModelofCar = m.ModelofCar, Manufacturer = m.Manufacturer, CarColour = m.CarColour, PurchasePrice = m.PurchasePrice, Tonnage = m.Tonnage, Displacement = m.Displacement, VehicleType = m.VehicleType, Status = m.Status };
            int i = db.Insertable(sql).ExecuteCommand();
            return i;
        }

        //接口生成承运单方法
        public List<TheCarrierSingle> theCarrierSingles(int page, int limit,string theCarrierSingleNumber,string ConsigneeTel)
        {
            List<TheCarrierSingle> list = db.Queryable<TheCarrierSingle>().ToList();

            return list;
        }
        //显示驾驶员
        public List<Driver> GetDrivers(string Dname) 
        {
            List<Driver> list = db.Queryable<Driver>().ToList();
            //判断是否为空
            if (!string.IsNullOrEmpty(Dname))
            {
                 list= db.Queryable<Driver>().Where(x => x.Dname.Contains(Dname)).ToList();
            }
            return list;
        }
        //添加驾驶员
        public int Add(Driver driver)
        {
            int i = db.Insertable(driver).ExecuteCommand();
            return i;
        }
        //删除驾驶员信息
        public int DelDeriver(int DId)
        {
            Driver driver = new Driver { DBit = false };
            int n = db.Updateable(driver).Where(p => p.DId == DId).ExecuteCommand();
            return n;
        }
        //更新驾驶员
        public int UptDeriver(Driver driver)
        {
            var t1 = db.Updateable(driver).ExecuteCommand();
            return t1;
        }
        //详情页
        public List<Driver> GetDetails(int id)
        {
            List<Driver> list = db.Queryable<Driver>().Where(x => x.DId == id).ToList();

            //if (!string.IsNullOrWhiteSpace(theCarrierSingleNumber))
            //{
            //    theCarrierSingleNumber = theCarrierSingleNumber.Trim();
            //    list = list.Where(t => t.TheCarrierSingleNumber == theCarrierSingleNumber).ToList();
            //}
            //if (!string.IsNullOrWhiteSpace(ConsigneeTel))
            //{
            //    ConsigneeTel = ConsigneeTel.Trim();
            //    list = list.Where(t => t.ConsigneeTel == theCarrierSingleNumber).ToList();
            //}
            //list = list.Skip((page - 1) * limit).Take(limit).ToList();
            //var model = new
            //{
            //    page = list,
            //    limit = limit,
            //};

            return list;
        }
        //删除车辆(假删)
        public string RemoveVehicle(string ids)
        {
            VehicleManage list = new VehicleManage { Status = false };
            var t7 = 0;
            string ne = "";
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i].ToString()==",")
                {
                    
                    continue;
                }
                t7 = db.Updateable(list).UpdateColumns(it => new { it.Status }).Where(p=>p.VehicleManageId==ids[i]).ExecuteCommand();
               
                if (t7==0)
                {
                    ne += ne + ids[i].ToString();
                }
            }
            if (!string.IsNullOrEmpty(ne))
            {
                return ne;
            }
            int t8 = db.Deleteable<TheTeamRelationship>().In(it => it.Vidd, new string[] { ids }).ExecuteCommand();
            return "yes";
        }
        //显示车队
        public List<FleetManagement> Fleet()
        {
            List<FleetManagement> list = db.Queryable<FleetManagement>().ToList();
            list = list.Where(m => m.Status == true).ToList();
            return list;
        }
        //删除车队.同删除车队关系
        public string RemoveMotorcade(string ids)
        {
            FleetManagement list = new FleetManagement { Status = false };
            var t7 = 0;
            string ne = "";
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i].ToString() == ",")
                {
                    continue;
                }
                var t5 = db.Updateable(list).UpdateColumns(it => new { it.Status }).Where(p => p.FleetManagementId ==  ids[i]).ExecuteCommand();
               //t7 = db.Updateable(list).UpdateColumns(it => new { it.Status }).Where(p => p.VehicleManageId == ids[i]).ExecuteCommand();
               
                if (t7 == 0)
                {
                    ne += ne + ids[i].ToString();
                }
            }
            var t4 = db.Deleteable<TheTeamRelationship>().In(it => it.Fidd, new string[] { ids }).ExecuteCommand();
            return t4.ToString();
        }
        //添加车队
        public int AddModtorcade(FleetManagement f, string ids)
        {
            int j = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i].ToString()==",")
                {
                    continue;
                }
                j += 1;
            }
            var son = new FleetManagement { PersonNumber = f.PersonNumber, Principal = f.Principal, PrincipalPhone = f.PrincipalPhone, Serialnumber = f.Serialnumber, TheteamName = f.TheteamName, vehicles = j };
            j += db.Insertable(son).ExecuteCommand();
            List<FleetManagement> getByWhere = db.Queryable<FleetManagement>().Where(it => it.PersonNumber == f.PersonNumber).ToList();
            
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i].ToString() == ",")
                {
                    continue;
                }
                string pea = ids[i].ToString();
                var sql = new TheTeamRelationship { Fidd = getByWhere[0].FleetManagementId, Vidd = Convert.ToInt32(pea) };
                j+= db.Insertable(sql).ExecuteCommand();
            }
            return j;
            
        }
     
        //删除承运单
        public int DeltheCarrierSingles(string ids)
        {
            string[] aa = ids.Split(',');
            int[] b = new int[aa.Length];
            for (int i = 0; i < aa.Length; i++)
            {
                int.TryParse(aa[i], out b[i]);
            }
            int flag = 0;
            for (int i = 0; i < b.Length; i++)
            {
                flag+= db.Deleteable<TheCarrierSingle>().In(new int[] { b[i] }).ExecuteCommand();
            }
     
            return flag;
        }

    }
}


       

        

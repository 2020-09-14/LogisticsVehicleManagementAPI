using LogisticsVehicleManagementAPI.Models;
﻿using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            if (!string.IsNullOrWhiteSpace(theCarrierSingleNumber))
            {
                theCarrierSingleNumber = theCarrierSingleNumber.Trim();
                list = list.Where(t => t.TheCarrierSingleNumber == theCarrierSingleNumber).ToList();
            }
            if (!string.IsNullOrWhiteSpace(ConsigneeTel))
            {
                ConsigneeTel = ConsigneeTel.Trim();
                list = list.Where(t => t.ConsigneeTel == theCarrierSingleNumber).ToList();
            }
            list = list.Skip((page - 1) * limit).Take(limit).ToList();
            var model = new
            {
                page = list,
                limit = limit,
            };
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

            

            return list;
        }
        //删除车辆
        public string RemoveVehicle(string ids)
        {
            
            var t7 = 0;
            
            string[] strArray = ids.Split(',');
            foreach (var item in strArray)
            {
                //删除车辆
                t7+= db.Deleteable<VehicleManage>().Where(p=>p.VehicleManageId == Convert.ToInt32(item)).ExecuteCommand();
                

            }
            foreach (var item in strArray)
            {
                //删除车辆跟车队之间的关系
                t7 += db.Deleteable<TheTeamRelationship>().Where(p=>p.Vidd== Convert.ToInt32(item)).ExecuteCommand();
            }
            
            if (t7 != 0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
            
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
            VehicleManage list1 = new VehicleManage { Status = false };
            
            string[] strArray = ids.Split(',');
            var t7 = 0;
            //db.Updateable(list).UpdateColumns(it => new { it.Status }).Where(p => p.FleetManagementId == Convert.ToInt32(item)).ExecuteCommand();
            foreach (var item in strArray)
            {
                List<TheTeamRelationship> t8 = db.Queryable<TheTeamRelationship>().Where(p => p.Fidd == Convert.ToInt32(item)).ToList();
                //删除车队
                t7 += db.Deleteable<FleetManagement>().Where(p => p.FleetManagementId == Convert.ToInt32(item)).ExecuteCommand();
                //删删除车队和车辆之间的关系
                t7 += db.Deleteable<TheTeamRelationship>().Where(it=>it.Fidd==Convert.ToInt32(item)).ExecuteCommand();
                //修改车辆的状态（改为空闲）
                foreach (var inte in t8)
                {
                    t7 += db.Updateable(list1).UpdateColumns(it => new { it.Status }).Where(p => p.VehicleManageId == inte.Vidd).ExecuteCommand();
                }
               
            }
           
            if (t7 != 0)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
            
            
           
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

        //修改车辆
        public int Upt(VehicleManage m)
        {
            var sql = new VehicleManage() { VehicleManageId=m.VehicleManageId, Licenseplatenumber = m.Licenseplatenumber, ModelofCar = m.ModelofCar, Manufacturer = m.Manufacturer, CarColour = m.CarColour, PurchasePrice = m.PurchasePrice, Tonnage = m.Tonnage, Displacement = m.Displacement, VehicleType = m.VehicleType, Status = m.Status };
            int i = db.Updateable(sql).ExecuteCommand();
            return i;
        }
        //车辆车队关系表
        public List<TheTeamRelationship> theTeams(string ids)
        {
            List<TheTeamRelationship> list = db.Queryable<TheTeamRelationship>().ToList();
            list = list.Where(p => p.Fidd == Convert.ToInt32(ids)).ToList();
            return list;
        }
        //修改的反填车辆
        public List<VehicleManage> TianUpt()
        {
            List<VehicleManage> list = db.Queryable<VehicleManage>().ToList();
           
            return list;
        }
        //修改的反填车辆
        public List<VehicleManage> TiaoUpt2(string ids)
        {
            var v1=db.Queryable<VehicleManage,TheTeamRelationship>((st,sc)=> new JoinQueryInfos(JoinType.Left,st.VehicleManageId==sc.Vidd)).Where("Status = 0 or Fidd = @ids ", new { ids = $"{ids}" }).ToList();
            
            return v1;
        }
        //反填车队
        public List<FleetManagement> UptFleeShow(string ids)
        {
            List<FleetManagement> list = db.Queryable<FleetManagement>().Where(p=>p.FleetManagementId==Convert.ToInt32(ids)).ToList();
          
            return list;
        }
        //修改车队
        public string UptMoodtorcade(FleetManagement f, string ids)
        {
            VehicleManage list = new VehicleManage { Status = true };
            //删除相关联的关系表
            int page= db.Deleteable<TheTeamRelationship>().Where(it=>it.Fidd==f.FleetManagementId).ExecuteCommand();
            int j = 0;
            
            string[] strArray = ids.Split(',');
            foreach (var item in strArray)
            {
                string inetr=  item.ToString();
                //添加新的和车辆的关系表
                var sql = new TheTeamRelationship() { Fidd = f.FleetManagementId, Vidd = Convert.ToInt32(inetr) };
                //把车辆改为使用中，（别的车队就用不了）
                j += db.Updateable(list).UpdateColumns(it => new { it.Status }).Where(p => p.VehicleManageId ==Convert.ToInt32(item)).ExecuteCommand();
                page += db.Insertable(sql).ExecuteCommand();
            }

            //修改车队信息
            var son = new FleetManagement { PersonNumber = f.PersonNumber, Principal = f.Principal, PrincipalPhone = f.PrincipalPhone, Serialnumber = f.Serialnumber, TheteamName = f.TheteamName, vehicles = j };
            page += db.Updateable(son).ExecuteCommand();
            if (page != 0)
            {
                //成功
                return "yes";
            }
            else
            {
                return "No";
            }
            
            
        }
        //详情
        public List<VehicleManage> Xq(string ids)
        {
            //查询车队下的车辆有哪些
            var v1 = db.Queryable<VehicleManage, TheTeamRelationship>((st, sc) => new JoinQueryInfos(JoinType.Left, st.VehicleManageId == sc.Vidd)).Where(" Fidd = @ids ", new { ids = $"{ids}" }).ToList();

            return v1;
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


       

        

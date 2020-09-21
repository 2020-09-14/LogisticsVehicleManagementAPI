using Google.Protobuf.WellKnownTypes;
using LogisticsVehicleManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<TheCarrierSingle> theCarrierSingles()
        {
            List<TheCarrierSingle> list = db.Queryable<TheCarrierSingle>().ToList();
//>>>>>>> b37c3d8419e4e73a91487ccddf96683d93bf25ec
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
        

        
    }
}


       

        

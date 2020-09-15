using LogisticsVehicleManagementAPI.Models;
using SqlSugar;
using System;
using System.Collections.Generic;

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
                InitKeyType = InitKeyType.Attribute
            });
        //接口生成承运单方法
        public List<TheCarrierSingle> theCarrierSingles()
        {
            List<TheCarrierSingle> list = db.Queryable<TheCarrierSingle>().ToList();
            return list;
        }
    }
}


       

        

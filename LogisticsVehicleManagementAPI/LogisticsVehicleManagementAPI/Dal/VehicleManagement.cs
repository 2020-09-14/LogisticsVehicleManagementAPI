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
                ConnectionString = "server=.;uid=sa;pwd=1234321;database=VehicleManagementSystem",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
    }
}


       

        

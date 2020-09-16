using LogisticsVehicleManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Dal
{
    public interface IVehicleManagement
    {
        //显示车辆
         List<VehicleManage> Show();
        //添加车辆
        int AddCar(VehicleManage m);
        //显示承运单
        List<TheCarrierSingle> theCarrierSingles();


    }
}

using LogisticsVehicleManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Dal
{
    public interface IVehicleManagement
    {

         

        //显示驾驶员
        List<Driver> GetDrivers(string Dname);

        //添加驾驶员
        int Add(Driver driver);

        //删除驾驶员
        int DelDeriver(int dId);

        //更新驾驶员
        int UptDeriver(Driver driver);

        //详情
        List<Driver> GetDetails(int id);


    

        //显示承运单
        List<TheCarrierSingle> theCarrierSingles(int page, int limit,string theCarrierSingleNumber,string ConsigneeTel);
        //删除承运单
        int DeltheCarrierSingles(string ids);
        //显示车辆
         List<VehicleManage> Show(string name);
        //添加车辆
        int AddCar(VehicleManage m);
        //删除车辆
        string RemoveVehicle(string ids);
        //显示车队
        List<FleetManagement> Fleet();
        //删除车队.同删除车队关系
        string RemoveMotorcade(string ids);
        //添加车队 同添加关系表（多条）
        int AddModtorcade(FleetManagement f, string ids);

     




    }
}

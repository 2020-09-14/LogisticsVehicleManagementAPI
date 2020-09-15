using LogisticsVehicleManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public interface IVehicleManagement
    {
        //显示承运单
        List<TheCarrierSingle> theCarrierSingles();
    }
}

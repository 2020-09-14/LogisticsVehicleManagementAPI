using LogisticsVehicleManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public interface IVehicleManagement
    {
//<<<<<<< HEAD
         List<VehicleManage> Show();
//=======
        //显示承运单
        List<TheCarrierSingle> theCarrierSingles();
//>>>>>>> b37c3d8419e4e73a91487ccddf96683d93bf25ec
    }
}

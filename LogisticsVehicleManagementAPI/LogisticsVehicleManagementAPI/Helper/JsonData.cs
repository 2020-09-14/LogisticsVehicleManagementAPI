using LogisticsVehicleManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsVehicleManagementAPI.Helper
{
    public class JsonData
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public List<TheCarrierSingle> data { get; set; }
    }
}

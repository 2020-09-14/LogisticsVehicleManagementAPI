using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsVehicleManagementAPI.Models
{
    //市
    public class Dic_City
    {
        public int id { get; set; }
        public string cityID { get; set; }
        public string city { get; set; }
        public string father { get; set; }
    }
}

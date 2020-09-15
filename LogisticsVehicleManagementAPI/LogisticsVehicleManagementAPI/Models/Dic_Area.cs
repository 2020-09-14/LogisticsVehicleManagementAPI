using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsVehicleManagementAPI.Models
{
    //区
    public class Dic_Area
    {
        public int id { get; set; }
        public string areaID { get; set; }
        public string area { get; set; }
        public string father { get; set; }
    }
}

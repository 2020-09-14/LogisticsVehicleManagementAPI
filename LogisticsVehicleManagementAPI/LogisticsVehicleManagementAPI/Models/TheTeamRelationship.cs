using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsVehicleManagementAPI.Models
{
    public class TheTeamRelationship
    {
        public int Tid   { get; set; }//主键
        public int Fidd  { get; set; }//车辆外键
        public int Vidd { get; set; }//车队外键

    }
}

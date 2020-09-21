using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsVehicleManagementAPI.Models
{
    public class FleetManagement
    {
        public int FleetManagementId { get; set; }//主键\
        public string Serialnumber      { get; set; }//车队编号
        public string TheteamName       { get; set; }//车队称号
        public string Principal         { get; set; }//负责人姓名
        public string PrincipalPhone    { get; set; }//负责人电话
        public int PersonNumber      { get; set; }   //车队人数
        public int vehicles          { get; set; }   //车辆数
        public bool Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsVehicleManagementAPI.Models
{
    public class Driver
    {
        public int DId { get; set; }//驾驶员编号
        public string Dname { get; set; }//驾驶员姓名
        public string Dphone { get; set; }//驾驶员电话
        public string Dlon { get; set; }//车牌编号
        public string Dzno { get; set; }//驾照编号
        public string Dsex { get; set; }//性别
        public DateTime Dbirthday { get; set; }//出生年月
        public string Dtype { get; set; }//准驾车型
        public string Dload { get; set; }//车辆载重
    }
}

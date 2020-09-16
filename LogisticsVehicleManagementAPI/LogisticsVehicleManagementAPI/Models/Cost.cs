using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsVehicleManagementAPI.Models
{
    //成本表
    public class Cost
    {
        //主键
        public int Id { get; set; }
        //燃料成本
        public int Fuel { get; set; }
        //修理成本
        public int Repair { get; set; }
        //通行成本
        public int Through { get; set; }
        //折旧成本
        public int Depreciation { get; set; }
        //其他费用
        public int Other { get; set; }
    }
}

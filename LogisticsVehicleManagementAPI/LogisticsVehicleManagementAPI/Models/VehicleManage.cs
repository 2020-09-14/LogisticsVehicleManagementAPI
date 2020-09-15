using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsVehicleManagementAPI.Models
{
    public class VehicleManage
    {
        public int VehicleManageId { get; set; }//主键
        public string Licenseplatenumber { get; set; }//车牌号
        public string ModelofCar { get; set; }//车辆型号
        public string Manufacturer { get; set; }//生产厂商
        public string CarColour { get; set; }//颜色，
        public string PurchasePrice { get; set; }//新车购置价
        public int Tonnage { get; set; }//吨位，
        public string Displacement { get; set; }//功率排气量，
        public string VehicleType { get; set; }//车辆种类，
        public string Img { get; set; }//图片，
        public bool Status { get; set; }//判断车辆是否在使用，

    }
}

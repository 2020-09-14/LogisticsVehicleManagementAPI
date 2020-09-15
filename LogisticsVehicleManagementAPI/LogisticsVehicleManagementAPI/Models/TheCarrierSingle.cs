using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsVehicleManagementAPI.Models
{
    //承运单类
    public class TheCarrierSingle
    {
        public int TheCarrierSingleId { get; set; }//承运单id

        public string TheCarrierSingleNumber { get; set; }//承运单号

        public string TypeOfGoods { get; set; }//货物类型

        public string TheCarrierFleet { get; set; }//承运车队

        public string TheCarrierVehicle { get; set; }//承运车辆

        public string DriversName { get; set; }//驾驶员姓名

        public int Moneys { get; set; }//承运欠款

        public int ReceiveTheCarrier { get; set; }//是否收货

        public string ConsignerName { get; set; }//发货人姓名

        public string ConsignerAddress { get; set; }//发货人地址

        public string ConsignerTel { get; set; }//发货人手机号

        public string ConsigneeName { get; set; }//收货人姓名

        public string ConsigneeAddress { get; set; }//收货人地址

        public string ConsigneeTel { get; set; }//收货人手机号
    }
}

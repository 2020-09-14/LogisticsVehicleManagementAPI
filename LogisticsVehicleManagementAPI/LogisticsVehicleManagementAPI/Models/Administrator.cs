using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsVehicleManagementAPI.Models
{
    public class Administrator
    {
        //客户登录表
        public int AdId { get; set; } //主键ID
        public string LoginID { get; set; } //用户名账号
        public string Cipher { get; set; }  //密码
        public string Phone { get; set; }  //手机号码
        public string IDnumber { get; set; }  //身份证号
    }
}

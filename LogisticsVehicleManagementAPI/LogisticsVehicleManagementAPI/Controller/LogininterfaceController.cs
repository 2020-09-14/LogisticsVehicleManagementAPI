using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using LogisticsVehicleManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsVehicleManagementAPI.Controller
{
    //登录控制器
    [Route("api/[controller]")]
    [ApiController]
    public class LogininterfaceController : ControllerBase
    {
        private IVehicleManagement _IVehicleManagement;
        public LogininterfaceController (IVehicleManagement ivchicle)
        {
            _IVehicleManagement = ivchicle;
        }

        //注册
        [Route("/api/Boarding")]
        [HttpPost]
        public int Boarding([FromForm]Administrator de)
        {
            int code= _IVehicleManagement.Boarding(de);
            return code;
        }

        //登录
        [HttpGet]
        [Route("/api/Login")]
        public int Login(string SName, string SPwd)
        {
            return _IVehicleManagement.Login(SName, SPwd);
        }

        //修改账号密码
        [Route("/api/Amend")]
        [HttpPost]
        public int Amend([FromForm] string Cipher, [FromForm] string IDnumber, [FromForm] string Phone)
        {
            return _IVehicleManagement.Amend(Cipher, IDnumber, Phone);
        }

        ////修改账号反填
        //public List<Administrator> Backfill(string SName, string SPwd)
        //{
        //    return _IVehicleManagement.Backfill(SName, SPwd);
        //}
    }
}

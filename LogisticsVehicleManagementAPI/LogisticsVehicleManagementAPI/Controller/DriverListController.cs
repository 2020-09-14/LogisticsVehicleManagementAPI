using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using LogisticsVehicleManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LogisticsVehicleManagementAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverListController : ControllerBase
    {
        private IVehicleManagement vehicle;
        public DriverListController(IVehicleManagement vehicleManagement)
        {
            vehicle = vehicleManagement;
        }
        //显示驾驶员
        [HttpGet]
        [Route("GetShow")]
        public string GetShow(string Dname)
        {
            List<Driver> list = vehicle.GetDrivers(Dname);
            string str = JsonConvert.SerializeObject(list);
            return str;
        }
        //添加驾驶员
        [HttpPost]
        [Route("/api/AddDriver")]
        public int AddDriver([FromForm] Driver driver)
        {
            int i = vehicle.Add(driver);
            return i;
        }
        //删除驾驶员
        [HttpGet]
        [Route("DelDeriver")]
        public int DelDeriver(int DId) 
        {
            int list = vehicle.DelDeriver(DId);
            return list;
        }
        //更新驾驶员
        [HttpGet]
        [Route("UptDeriver")]
        public int UptDeriver([FromForm]Driver driver) 
        {
            int upt = vehicle.UptDeriver(driver);
            return upt;
        }
        //详情
        [HttpGet]
        [Route("GetDetails")]
        public string GetDetails(int id) 
        {
            List<Driver> list = vehicle.GetDetails(id);
            string str = JsonConvert.SerializeObject(list);
            return str;
        }
    }
}

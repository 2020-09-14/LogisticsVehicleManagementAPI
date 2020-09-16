using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    public class MotorcadeapiController : ControllerBase
    {
        private IVehicleManagement vehicle;
        public MotorcadeapiController(IVehicleManagement vehicleManagement)
        {
             vehicle = vehicleManagement;
        }
        //车辆显示
        [HttpGet]
        [Route("/api/Show")]
        public IActionResult Show()
        {
            List<VehicleManage> list = vehicle.Show();
            string json = JsonConvert.SerializeObject(list);
            return Ok(json); ;
        }
        
        //添加车辆
        [HttpPost]
        [Route("/api/AddCar")]
        public int AddCar([FromForm]VehicleManage m)
        {
            int code = vehicle.AddCar(m);
            return code;
        }
    }
}

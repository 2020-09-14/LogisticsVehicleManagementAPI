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
        public IActionResult Show(string name)
        {
            List<VehicleManage> list = vehicle.Show(name);
            string json = JsonConvert.SerializeObject(list);
            return Ok(json); ;
        }
        [Route("/api/AddCar")]
        //添加车辆
        [HttpPost]
        public int AddCar([FromForm] VehicleManage m)
        {
            int code = vehicle.AddCar(m);
            return code;
        }
        //删除车辆
        [Route("/api/Delete")]
        [HttpPost("{name}")]
        public ActionResult<string> RemoveVehicle([FromForm] string name)
        {
            if (name == null)
            {
                return Ok(1);

            }
            return Ok(vehicle.RemoveVehicle(name));
        }
        //显示车队
        [Route("/api/Dshow")]
        [HttpGet]
        public ActionResult MotorcadeList()
        {
            List<FleetManagement> list = vehicle.Fleet();
            string json = JsonConvert.SerializeObject(list);
            return Ok(json);
        }
        //删除车队.同删除车队关系
        [Route("/api/Remove")]
        [HttpPost("{name}")]
        public string RemoveMotorcade([FromForm] string name)
        {

            return vehicle.RemoveMotorcade(name);
        }
        [Route("/api/AddModtorcade")]
        //添加车辆
        [HttpPost]
        public int AddModtorcade([FromForm] FleetManagement f, [FromForm] string ids)
        {
            return vehicle.AddModtorcade(f, ids);
        }
        //车辆修改反填
        [Route("/api/CarTian")]
        [HttpGet]
        public IActionResult CarTian(string ids)
        {
            string name = "";
            List<VehicleManage> list = vehicle.Show(name);

            list = list.Where(p => p.VehicleManageId == Convert.ToInt32(ids)).ToList();

            string json = JsonConvert.SerializeObject(list);

            return Ok(json);
        }
    }
}

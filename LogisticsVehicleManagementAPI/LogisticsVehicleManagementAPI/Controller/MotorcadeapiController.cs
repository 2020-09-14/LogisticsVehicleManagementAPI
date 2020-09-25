using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Dal;
using LogisticsVehicleManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public IActionResult Show(string name,int page=0,int rows=0)
        {
            List<VehicleManage> list = vehicle.Show(name);
            int Tocount = list.Count;
            if (page != 0 && rows != 0)
            {
                list = list.Skip((page - 1) * rows).Take(rows).ToList();
            }
            //string json = JsonConvert.SerializeObject(list);
            var model = new
            {
                count = Tocount,
                list = list
            };
            
            return Ok(model);
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
        //修改车辆
        [Route("/api/CarUpt")]
        [HttpPost]
        public IActionResult actionResult([FromForm]VehicleManage m)
        {
            int i = vehicle.Upt(m);
            return Ok(i);
        }
        //反填车队（车辆信息）
        [Route("/api/CarTianCheck")]
        [HttpGet]
        public IActionResult CarTianCheck([FromQuery]string ids)
        { 
            
            return Ok(JsonConvert.SerializeObject(vehicle.theTeams(ids)));
        }
        //修改反填车队
        [Route("/api/UptFleeShow")]
        [HttpGet]
        public IActionResult UptFleeShow([FromQuery]string ids)
        {
            string json = JsonConvert.SerializeObject(vehicle.UptFleeShow(ids));
            return Ok(json);
        }
        //修改反填车辆
        [Route("/api/CarTianUpt")]
        [HttpGet] 
        public IActionResult CarTiaoUpt([FromQuery]string ids) 
        {
            string sql = JsonConvert.SerializeObject(vehicle.TiaoUpt2(ids));
            return Ok(sql);
        }
      
        //修改车队
        [Route("/api/UptMored")]
        [HttpPost]
        public IActionResult UptMoodtorcade([FromForm]FleetManagement m, [FromForm] string ids)
        {
            string i = vehicle.UptMoodtorcade(m,ids);
            return Ok(i);
        }
        //修改反填车辆
        [Route("/api/Xq")]
        [HttpGet]
        public IActionResult Xq([FromQuery] string ids)
        {
            string sql = JsonConvert.SerializeObject(vehicle.Xq(ids));
            return Ok(sql);
        }
    }
}

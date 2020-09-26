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
    public class CostController : ControllerBase
    {
        private IVehicleManagement _vehicleManagement;
        public CostController(IVehicleManagement vehicleManagement)
        {
            _vehicleManagement = vehicleManagement;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddCost")]
        public int AddCost([FromForm]Cost cost)
        {
            int i = _vehicleManagement.AddCost(cost);
            return i; 
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [Route("/api/GetCost")]
        [HttpGet] 
        public string GetCost()
        {
            List<Cost> list = _vehicleManagement.GetCost();
            string str = JsonConvert.SerializeObject(list);
            return str;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [Route("/api/DeleteCost")]
        [HttpGet]
        public IActionResult DeleteCost([FromQuery] int Ids)
        {
            int i = _vehicleManagement.DeleteCost(Ids);
            return Ok(i);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [Route("/api/UpdateCost")]
        [HttpPost]
        public int UpdateCost([FromForm]Cost m)
        {
            return _vehicleManagement.Update(m);
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [Route("/api/fantiancost")]
        [HttpGet]
        public IActionResult Fancost(int ids)
        {
            List<Cost> list = _vehicleManagement.FanCost(ids);
            string json = JsonConvert.SerializeObject(list);
            return Ok(json);
        }
    }
}

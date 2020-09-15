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
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcadeapiController : ControllerBase
    {
        private IVehicleManagement vehicle;
        public MotorcadeapiController(IVehicleManagement vehicleManagement)
        {
             vehicle = vehicleManagement;
        }
        [HttpGet]
        public List<VehicleManage> Show()
        {
            List<VehicleManage> list = vehicle.Show();
            return list;
        }
    }
}

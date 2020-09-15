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
    public class TheCarrierSingleController : ControllerBase
    {
        private IVehicleManagement _vehicleManagement;
        public TheCarrierSingleController(IVehicleManagement vehicleManagement)
        {
            _vehicleManagement = vehicleManagement;
        }
        [HttpGet]
        public IActionResult GettheCarrierSingles()
        {
            List<TheCarrierSingle> theCarrierSingles = _vehicleManagement.theCarrierSingles();
            return Ok(theCarrierSingles);
        }
    }
}

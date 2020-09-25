using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dal;
using LogisticsVehicleManagementAPI.Helper;
using LogisticsVehicleManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public IActionResult  GettheCarrierSingles(int page,int limit,[FromQuery] string theCarrierSingleNumber,string ConsigneeTel,string ReceiveTheCarrier)
        {
            List<TheCarrierSingle> theCarrierSingles = _vehicleManagement.theCarrierSingles(theCarrierSingleNumber,ConsigneeTel, ReceiveTheCarrier);
            var count = theCarrierSingles.Count;
            theCarrierSingles = theCarrierSingles.Skip((page - 1) * limit).Take(limit).ToList();
            JsonData json = new JsonData() { code = 0, msg = "", count = count+1, data = theCarrierSingles };
            return Ok(json);
        }
        [Route("/api/Del")]
        [HttpPost]
        public IActionResult DeltheCarrierSingles([FromQuery]string ids)
        {
           
            int code = _vehicleManagement.DeltheCarrierSingles(ids);
            return Ok(code);
        }
        [Route("/api/Add")]
        [HttpPost]
        public IActionResult AddtheCarrierSingles([FromForm] TheCarrierSingle the)
        {
            int code = _vehicleManagement.AddtheCarrierSingles(the);
            return Ok(code);
        }

      
    }
}

using GrainInterfaces;
using Grains;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SensorController : ControllerBase
    {
        private readonly IClusterClient clusterClient;

        public SensorController(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }

        [HttpPost]
        [Route("api/sensor")]
        public async Task<IActionResult> Post(SensorViewModel model)
        {
            var sensor = clusterClient.GetGrain<ISensorGrain>(model.SendorId);
            await sensor.SetTemprature(new SensorModel
            {
                Temprature = model.Temprature
            });

            return Ok();

        }

        [HttpPost]
        [Route("api/sensor/{sensorId}")]
        public async Task<IActionResult> Get(int sensorId)
        {
            var sensor = clusterClient.GetGrain<ISensorGrain>(sensorId);
            var temp = await sensor.GetTemprature();
            return Ok(temp);

        }
    }
}

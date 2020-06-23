using GrainInterfaces;
using Grains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Hubs;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SensorController : ControllerBase
    {
        private readonly IClusterClient clusterClient;
        private readonly IHubContext<NotifyHub, INotifyHub> _notifyHub;
        public SensorController(IClusterClient clusterClient, IHubContext<NotifyHub, INotifyHub> notifyHub)
        {
            this.clusterClient = clusterClient;
            _notifyHub = notifyHub;
        }

        [HttpPost]
        [Route("api/sensor")]
        public async Task<IActionResult> Post([FromBody]SensorViewModel model)
        {
            var sensor = clusterClient.GetGrain<ISensorGrain>(model.SendorId);
            await sensor.SetTemprature(new SensorModel
            {
                Temprature = model.Temprature
            });
            await _notifyHub.Clients.All.SendSensorData(model.SendorId, model.Temprature);
            return Ok();

        }

        [HttpGet]
        [Route("api/sensor/{sensorId}")]
        public async Task<IActionResult> Get(int sensorId)
        {
            var sensor = clusterClient.GetGrain<ISensorGrain>(sensorId);
            var temp = await sensor.GetTemprature();
            return Ok(temp);

        }
    }
}

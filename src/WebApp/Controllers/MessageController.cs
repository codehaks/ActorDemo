using Microsoft.AspNetCore.Mvc;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grains;
using GrainInterfaces;

namespace WebApp.Controllers
{
    public class MessageController : ControllerBase
    {
        private readonly IClusterClient clusterClient;

        public MessageController(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }
        [Route("api/message/{userId}/{body}")]
        public async Task<IActionResult> Get(int userId,string body)
        {
            var g = clusterClient.GetGrain<IHello>(userId);
            var result=await g.SayHello(body);
            return Ok(result);

        }

        [Route("api/messages/{userId}")]
        public async Task<IActionResult> GetMessages(int userId)
        {
            var g = clusterClient.GetGrain<IHello>(userId);
            var result = await g.GetMessages();
            return Ok(result);

        }
    }
}

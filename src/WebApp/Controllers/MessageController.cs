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
        public async Task<IActionResult> Get(string userId, string body)
        {
            var g = clusterClient.GetGrain<IMessageGrain>(userId);
            

            await g.Send(new MessageModel
            {
                Body = body,
                UserName = userId
            });
            return Ok("Message sent!");

        }

        [Route("api/messages/{userId}")]
        public async Task<IActionResult> GetMessages(string userId)
        {
            var g = clusterClient.GetGrain<IMessageGrain>(userId);
            var result = await g.GetHistory();
            return Ok(result);

        }
    }
}

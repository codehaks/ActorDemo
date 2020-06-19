using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class MessageController:ControllerBase
    {
        [Route("api/message")]
        public  IActionResult Get()
        {
            return Ok("done");
        }
    }
}

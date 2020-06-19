using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GrainInterfaces
{
    public class MessageModel
    {
        public string UserName { get; set; }
        public string Body { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}

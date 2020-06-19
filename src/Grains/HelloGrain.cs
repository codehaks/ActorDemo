using GrainInterfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    public class HelloGrain : Orleans.Grain, IMessageGrain
    {
        private readonly ILogger logger;
        private readonly List<string> _messageList;

        public HelloGrain(ILogger<HelloGrain> logger)
        {
            this.logger = logger;
            _messageList = new List<string>();
        }

        Task<string> IMessageGrain.Send(string greeting)
        {
            logger.LogInformation($"\n SayHello message received: greeting = '{greeting}'");
            _messageList.Add(greeting);
            return Task.FromResult($"\n {this.GetPrimaryKey()} said: '{greeting}', so HelloGrain says: "+greeting.Reverse().ToString());
        }

        Task<List<string>> IMessageGrain.GetHistory()
        {
            return Task.FromResult(_messageList);
        }
    }
}

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
        private readonly List<MessageModel> _messageList;

        public HelloGrain(ILogger<HelloGrain> logger)
        {
            this.logger = logger;
            _messageList = new List<MessageModel>();
        }

        Task IMessageGrain.Send(MessageModel greeting)
        {
            greeting.TimeCreated = DateTime.Now;

            logger.LogInformation($"\n message received from {greeting.UserName}: '{greeting.Body}' at {greeting.TimeCreated.ToShortTimeString()}");
            

            _messageList.Add(greeting);
            return Task.CompletedTask;
        }

        Task<List<MessageModel>> IMessageGrain.GetHistory()
        {
            return Task.FromResult(_messageList);
        }
    }
}

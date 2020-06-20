using GrainInterfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Runtime;
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
        private readonly IPersistentState<MessageModel> _messageState;

        public HelloGrain(ILogger<HelloGrain> logger,
            [PersistentState("message", "messageStore")] IPersistentState<MessageModel> messageState)
        {
            this.logger = logger;
            _messageState = messageState;
            _messageList = new List<MessageModel>();
        }

        async Task IMessageGrain.Send(MessageModel greeting)
        {
            greeting.TimeCreated = DateTime.Now;
            
            logger.LogInformation($"\n message received from {greeting.UserName}: '{greeting.Body}' at {greeting.TimeCreated.ToShortTimeString()}");
            
            _messageList.Add(greeting);
            await _messageState.WriteStateAsync();
//            return Task.CompletedTask;
        }

        Task<List<MessageModel>> IMessageGrain.GetHistory()
        {
            return Task.FromResult(_messageList);
        }
    }
}

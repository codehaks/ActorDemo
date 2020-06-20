using GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    class StatusGrain : Orleans.Grain, IStatusGrain
    {
        public string Status { get; set; }

        public Task<string> GetStatus()
        {
            return Task.FromResult(Status);
        }

        public Task SetStatus(string status)
        {
            Status = status;
            return Task.CompletedTask;
        }
    }
}

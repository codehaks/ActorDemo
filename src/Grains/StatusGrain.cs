using GrainInterfaces;
using Orleans.Providers;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    [StorageProvider(ProviderName = "statusStore")]
    class StatusGrain : Orleans.Grain<StatusModel>, IStatusGrain
    {
        public Task<StatusModel> GetStatus()
        {
            return Task.FromResult(State);
        }

        public async Task SetStatus(string status)
        {
            State = new StatusModel
            {
                Name = status
            };
            await base.WriteStateAsync();
        }
    }
}

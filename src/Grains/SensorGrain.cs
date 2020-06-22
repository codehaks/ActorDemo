using GrainInterfaces;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    [StorageProvider(ProviderName = "sensorStore")]
    public class SensorGrain : Orleans.Grain<SensorModel>, ISensorGrain
    {
        public Task<SensorModel> GetTemprature()
        {
            return Task.FromResult(State);
        }

        public async Task SetTemprature(SensorModel model)
        {
            State = model;
            await base.WriteStateAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface ISensorGrain:Orleans.IGrainWithIntegerKey
    {
        Task SetTemprature(SensorModel status);
        Task<SensorModel> GetTemprature();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IStatusGrain:Orleans.IGrainWithStringKey
    {
        Task SetStatus(string status);
        Task<string> GetStatus();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IMessageGrain : Orleans.IGrainWithStringKey
    {
        Task<string> Send(string greeting);
        Task<List<string>> GetHistory();
    }
}

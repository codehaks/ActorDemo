using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IMessageGrain : Orleans.IGrainWithStringKey
    {
        Task Send(MessageModel model);
        Task<List<MessageModel>> GetHistory();
    }
}

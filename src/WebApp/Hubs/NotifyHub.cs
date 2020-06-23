using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Hubs
{
    public class NotifyHub : Microsoft.AspNetCore.SignalR.Hub<INotifyHub>
    {
    }

    public interface INotifyHub
    {
        Task SendSensorData(int sensorId,int temprature);
    }
}

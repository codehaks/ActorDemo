using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempSimApp
{
    [Serializable]
    public class SensorViewModel
    {
        public int SendorId { get; set; }
        public int Temprature { get; set; }
    }
}

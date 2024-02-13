using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BI.Interfaces;

namespace Test.BI.Services
{
    public class StatusService : IStatus
    {
        public bool IsAvailable => new Random().Next(0, 2) != 0;
    }
}

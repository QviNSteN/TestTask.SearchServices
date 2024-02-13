using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Entities;

namespace Test.Data.Base
{
    public abstract class BaseResponse
    {
        public abstract BaseResponse GetResponse(IEnumerable<Route> routes);
    }
}

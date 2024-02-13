using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Base;

namespace Test.Providers.BI.Interfaces
{
    public interface IData<Response>
    {
        Response Result { get; }

        public Task<Response> GetData<Response, Filter>(Filter filter) where Response : BaseResponse
                                                                 where Filter : BaseRequest;
    }
}

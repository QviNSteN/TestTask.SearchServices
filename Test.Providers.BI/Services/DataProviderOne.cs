using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Base;
using Test.Data.ProviderOne;
using Test.Providers.BI.Interfaces;

namespace Test.Providers.BI.Services
{
    public class DataProviderOne : IData<ProviderOneSearchResponse>
    {
        public ProviderOneSearchResponse Result => new ProviderOneSearchResponse();
        public readonly DataRepository _repository;

        public DataProviderOne(DataRepository repository)
        {
            _repository = repository;
        }

        public Task<Response> GetData<Response, Filter>(Filter filter) where Response : BaseResponse
                                                                 where Filter : BaseRequest                                                                  
            => Task.FromResult((Response)Result.GetResponse(_repository.DataBase.Where(x => filter.Filter(x))));
    }
}

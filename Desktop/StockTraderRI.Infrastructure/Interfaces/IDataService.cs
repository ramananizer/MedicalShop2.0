using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTraderRI.Infrastructure.Interfaces
{
    public interface IDataService
    {
        T GetResult<T>(string methodName, object[] inputParams);
    }
}

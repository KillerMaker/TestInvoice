using System.Data.Common;
using System.Data.SqlClient;

namespace TestInvoiceAPI.DataBase_Handler
{
    public interface IDbHandler<in Parameter, out DataReader> 
        where Parameter : DbParameter  where DataReader : DbDataReader
    {
      
        public Task<int> RunCommand(string command, params Parameter[] parameters);
        public IAsyncEnumerable<T> RunQuery<T>(string query, Func<DataReader, T> mapper, params Parameter[] parameters);
    }
}

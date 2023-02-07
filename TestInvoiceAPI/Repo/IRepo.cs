using System.Data.SqlClient;
using TestInvoiceAPI.Models;

namespace TestInvoiceAPI.Repo
{
    public interface IRepo<T>
    {
        public Task<int> Create(T obj);
        public Task<int> Update(T obj);
        public Task Delete(int id);
        public IAsyncEnumerable<T> GetAll();
        public IAsyncEnumerable<T> GetById(int id);
        public T Map(SqlDataReader reader);
    }
}

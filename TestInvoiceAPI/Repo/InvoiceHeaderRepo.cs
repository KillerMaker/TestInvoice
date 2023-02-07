using System.Data.SqlClient;
using TestInvoiceAPI.DataBase_Handler;
using TestInvoiceAPI.Models;

namespace TestInvoiceAPI.Repo
{
    public class InvoiceHeaderRepo : IRepo<InvoiceHeader>
    {
        private ISqlServerHandler _dbHandler;
        private IConfigurationSection _config;
 
        public event Action<InvoiceHeader> OnAddInvoiceDetail;
        public InvoiceHeaderRepo(ISqlServerHandler dbHandler, IConfigurationSection config)
        {
            _dbHandler = dbHandler;
            _config = config;
        }

        public async Task<int> Create(InvoiceHeader obj)
        {
            //OnAddInvoiceDetail.Invoke(obj);

            await foreach (var item in _dbHandler.RunQuery(_config.GetSection("InvoiceHeader").GetValue<string>("Insert"),
                (reader) => int.Parse(reader[0].ToString()),
                new SqlParameter("@CustomerId", obj.customerId),
                new SqlParameter("@TotalItbis", obj.totalItbis),
                new SqlParameter("@SubTotal", obj.subTotal),
                new SqlParameter("@Total", obj.total)))
                    return item;

            return 0;
        }
            

        public async Task Delete(int id) =>
           await _dbHandler.RunCommand(_config.GetSection("InvoiceHeader").GetValue<string>("Delete"),
                new SqlParameter("@Id", id));

        public async IAsyncEnumerable<InvoiceHeader> GetAll()
        {
           await foreach(var item in _dbHandler.RunQuery(_config.GetSection("InvoiceHeader").GetValue<string>("GetAll"),Map))
                yield return item;
        }

        public async IAsyncEnumerable<InvoiceHeader> GetById(int id)
        {
            await foreach (var item in _dbHandler.RunQuery(_config.GetSection("InvoiceHeader").GetValue<string>("GetById"), Map, new SqlParameter("@Id", id)))
                yield return item;
        }

        public InvoiceHeader Map(SqlDataReader reader) =>
            new InvoiceHeader(
                int.Parse(reader[0].ToString()),
                int.Parse(reader[1].ToString()),
                decimal.Parse(reader[2].ToString()),
                decimal.Parse(reader[3].ToString()),
                decimal.Parse(reader[4].ToString()));

        public Task<int> Update(InvoiceHeader obj) =>
            _dbHandler.RunCommand(_config.GetSection("InvoiceHeader").GetValue<string>("Update"),
                new SqlParameter("@Id", obj.id),
                new SqlParameter("@CustomerId", obj.customerId),
                new SqlParameter("@TotalItbis", obj.totalItbis),
                new SqlParameter("@SubTotal",obj.subTotal),
                new SqlParameter("@Total", obj.total));
    }
}

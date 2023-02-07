using System.Data.SqlClient;
using TestInvoiceAPI.DataBase_Handler;
using TestInvoiceAPI.Models;

namespace TestInvoiceAPI.Repo
{
    public class InvoiceDetailRepo : IRepo<InvoiceDetail>
    {
        private ISqlServerHandler _dbHandler;
        private IConfigurationSection _config;

        public InvoiceDetailRepo(ISqlServerHandler dbHandler, IConfigurationSection config)
        {
            _dbHandler = dbHandler;
            _config = config;
        }
        public async Task<int> Create(InvoiceDetail obj) =>
            await _dbHandler.RunCommand(_config.GetSection("InvoiceDetail").GetValue<string>("Insert"),
                new SqlParameter("@InvoiceId", obj.invoiceId),
                new SqlParameter("@quantity", obj.quantity),
                new SqlParameter("@price", obj.price),
                new SqlParameter("@subTotal", obj.subTotal),
                new SqlParameter("@totalItbis", obj.totalItbis),
                new SqlParameter("@total", obj.total));

        public async Task Delete(int id) =>
              await _dbHandler.RunCommand(_config.GetSection("InvoiceDetail").GetValue<string>("Delete"),
                  new SqlParameter("@Id", id));

        public async IAsyncEnumerable<InvoiceDetail> GetAll()
        {
            await foreach(var item in _dbHandler.RunQuery(_config.GetSection("InvoiceDetail").GetValue<string>("GetAll"),Map))
                yield return item;
        }

        public async IAsyncEnumerable<InvoiceDetail> GetById(int id)
        {
            await foreach (var item in _dbHandler.RunQuery(_config.GetSection("InvoiceDetail").GetValue<string>("GetById"), Map,
                new SqlParameter("@Id", id)))
                yield return item;
        }

        public InvoiceDetail Map(SqlDataReader reader) =>
            new InvoiceDetail(
                int.Parse(reader[0].ToString()),
                int.Parse(reader[1].ToString()),
                int.Parse(reader[2].ToString()),
                decimal.Parse(reader[3].ToString()),
                decimal.Parse(reader[4].ToString()),
                decimal.Parse(reader[5].ToString()),
                decimal.Parse(reader[6].ToString()));

        public async Task<int> Update(InvoiceDetail obj) =>
            await _dbHandler.RunCommand(_config.GetSection("InvoiceDetail").GetValue<string>("Insert"),
                new SqlParameter("@Id", obj.id),
                new SqlParameter("@InvoiceId", obj.invoiceId),
                new SqlParameter("@quantity", obj.quantity),
                new SqlParameter("@price", obj.price),
                new SqlParameter("@subTotal", obj.subTotal),
                new SqlParameter("@totalItbis", obj.totalItbis),
                new SqlParameter("@total", obj.total));
    }
}

using System.Data.SqlClient;
using TestInvoiceAPI.DataBase_Handler;
using TestInvoiceAPI.Models;

namespace TestInvoiceAPI.Repo
{
    public class CustomerRepo : IRepo<Customer>
    {
        private ISqlServerHandler _dbHandler;
        private IConfigurationSection _config;
        public CustomerRepo(ISqlServerHandler dbHandler, IConfigurationSection config)
        {
            _dbHandler = dbHandler;
            _config = config;
        }

        public async Task<int> Create(Customer obj) =>
            await _dbHandler.RunCommand(_config.GetSection("Customer").GetValue<string>("Insert"),
                new SqlParameter("@Name",obj.name),
                new SqlParameter("@Address",obj.address),
                new SqlParameter("@Status",obj.status? 1:0),
                new SqlParameter("@CustomerTypeId", obj.customerType));

        public async Task Delete(int id) =>
            await _dbHandler.RunCommand(_config.GetSection("Customer").GetValue<string>("Delete"),
                new SqlParameter("@Id", id));

        public async IAsyncEnumerable<Customer> GetAll()
        {
              await foreach(var item in _dbHandler.RunQuery(_config.GetSection("Customer").GetValue<string>("GetAll"),Map))
                yield return item;
        }
             
        public async IAsyncEnumerable<Customer> GetById(int id)
        {
            await foreach (var item in _dbHandler.RunQuery(_config.GetSection("Customer").GetValue<string>("GetById"), 
                Map, new SqlParameter("@Id", id)))
                yield return item;
        }

        public async Task<int> Update(Customer obj) =>
            await _dbHandler.RunCommand(_config.GetSection("Customer").GetValue<string>("Update"),
                new SqlParameter("@Id",obj.id),
                new SqlParameter("@Name", obj.name),
                new SqlParameter("@Address", obj.address),
                new SqlParameter("@Status", obj.status? 1:0),
                new SqlParameter("@CustomerTypeId", obj.customerType));

        public Customer Map(SqlDataReader reader) =>
                new Customer(
                    int.Parse(reader[0].ToString()),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    bool.Parse(reader[3].ToString()),
                    int.Parse(reader[4].ToString()));

    }
}

using System.Data.SqlClient;

namespace TestInvoiceAPI.DataBase_Handler
{
    public interface ISqlServerHandler : IDbHandler<SqlParameter, SqlDataReader> { }

}

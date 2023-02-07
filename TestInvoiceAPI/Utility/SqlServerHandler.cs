#nullable disable
using System.Data.SqlClient;

namespace TestInvoiceAPI.DataBase_Handler
{
    public class SqlServerHandler : ISqlServerHandler
    {
        private string _strCon;
        public SqlServerHandler(string strCon) =>_strCon = strCon;

        public async Task<int> RunCommand(string query, params SqlParameter[] parameters)
        {
            using SqlConnection connection = new SqlConnection(_strCon);
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddRange(parameters);

            await connection.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();

            await connection.CloseAsync();

            return rowsAffected;
        }

        public async IAsyncEnumerable<T> RunQuery<T>(string query, Func<SqlDataReader,T>mapper, params SqlParameter[] parameters)
        {
            using SqlConnection connection = new SqlConnection(_strCon);

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            await connection.OpenAsync();
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            while(await reader.ReadAsync()) 
                yield return mapper(reader);

            await connection.CloseAsync();
            yield break;
        }

    }
}

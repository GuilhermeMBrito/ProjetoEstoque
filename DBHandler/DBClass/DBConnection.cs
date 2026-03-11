using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace DBHandler.DBClass
{
    public class DBConnection
    {
        private string _connectionString { get; set; }
        public DBConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IList<IList<string>>> ConsultaVariosSQLAsync(string sqlCommando)
        {
            IList<IList<string>> list = new List<IList<string>>();
            await using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            await using SqlCommand command = new SqlCommand(sqlCommando, connection);
            await using SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                IList<string> array = new List<string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var obj = reader.GetValue(i);
                    if (obj == null)
                    {
                        array.Add("");
                    }
                    else
                    {
                        array.Add(reader.GetValue(i).ToString());
                    }
                }
                list.Add(array);
            }
            return list;
        }
        public async Task<IList<string>> ConsultaUmSQLAsync(string sqlCommando)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                await using SqlCommand command = new SqlCommand(sqlCommando, connection);
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                IList<string> list = new List<string>();
                while (await reader.ReadAsync())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var obj = reader.GetValue(i);
                        if (obj == null)
                        {
                            list.Add("");
                        }
                        else
                        {
                            list.Add(reader.GetValue(i).ToString());
                        }
                    }
                    return list;
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<int> EnviarDadosSQLAsync(string sqlCommando)
        {
            await using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            await using SqlCommand command = new SqlCommand(sqlCommando, connection);
            return command.ExecuteNonQuery();
        }
    }
}

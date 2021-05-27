 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CRUD.Produtos.DAL
{
    public class ConexaoSql
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;
        public ConexaoSql(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Produtos");            
        }

        public DataTable ExecuteReader(string query)
        {
            DataTable resultado = null;
            using (_sqlConnection = new SqlConnection(_connectionString))
            {
                _sqlConnection.Open();

                using(SqlCommand command = new SqlCommand(query,_sqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        resultado = new DataTable();
                        resultado.Load(reader);
                    }                    
                }
            }
            return resultado;
        }

        public void ExecuteNonQuery(string query)
        {
            using(_sqlConnection = new SqlConnection(_connectionString))
            {
                _sqlConnection.Open();

                using (SqlCommand command = new SqlCommand(query, _sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

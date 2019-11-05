using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClienteAcademiaCsharp.Data
{
    class ConexaoBd
    {
        private const string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=AulaBancoDeDados;Trusted_connection=true;";
        //Server=(localdb)\\mssqllocaldb;Database=AulaBancoDeDados;Trusted_connection=true;

        private List<SqlParameter> _parametros = new List<SqlParameter>();

        public void AddParametro(string nome, object value)
        {
            _parametros.Add(new SqlParameter(nome, value));
        }
        //Para realizar update, delete, insert
        public int ExecuteNonQuery(string query)
        {
            //Criando uma nova conexão
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlcommand = new SqlCommand(query, connection))
                {
                    foreach(var parametro in _parametros)
                    {
                        sqlcommand.Parameters.Add(parametro);
                    }
                    //_parametros.ForEach(x => sqlcommand.Parameters.Add(x));
                    try
                    {
                        connection.Open();
                        return sqlcommand.ExecuteNonQuery();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        //Para realizar select
        public DataTable ExecuteReader(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlcommand = new SqlCommand(query, connection))
                {
                    //foreach (var parametro in _parametros)
                    //{
                    //    sqlcommand.Parameters.Add(parametro);
                    //}
                    _parametros.ForEach(x => sqlcommand.Parameters.Add(x));

                    try
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = sqlcommand.ExecuteReader())
                        {
                            var dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            dataReader.Close();
                            return dataTable;
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}

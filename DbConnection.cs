using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SarasaviLibrarySystem
{
    public class DbConnection
    {
        private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=SarasaviDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Open connection
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Execute query
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Execute non-query
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
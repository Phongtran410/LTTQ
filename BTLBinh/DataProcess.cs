﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLBinh
{
    internal class DataProcess
    {
        private string connectionString = @"Data Source=PHONG\PHONG;Initial Catalog=LTTQ;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public DataTable DataConnect(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        connection.Open();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // Thực thi câu lệnh không trả về kết quả
                }
            }
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace TestConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            // App.Config에서 선언한 DB를 connectionString로 가져옴
            string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

            using (SqlConnection sqlCon = new SqlConnection())
            {
                sqlCon.ConnectionString = connectionString;

                // DB 연결
                sqlCon.Open();

                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM table";

                SqlDataReader reader = cmd.ExecuteReader();

                // reader를 사용 > 레코드 조회
                while (reader.Read())
                {
                    // 컬럼 하나씩
                    string seq = reader.GetString(0);
                    string name = reader.GetString(1);
                    string price = reader.GetString(2);
                    string stock = reader.GetString(3);

                    Console.WriteLine($"{seq}, {name}, {price}, {stock}");
                }

                reader.Close();


            }

        }
    }
}

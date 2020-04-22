using System;
using System.Data;
using System.Data.SqlClient;
namespace FirstProject
{
    public class EntryToSystem
    {
        public string Login{get; set;}
        public string Password{get;set;}
        public const string AdminPassword = "6BK98F54Dg";
        public int CheckAccount(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string checkSqlCommand = string.Format($"select password from Client where PhoneNumber ='{Login}' ");
            SqlCommand command = new SqlCommand(checkSqlCommand, scon);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                return 1;
            }
            else return 0;
        }
        public int CheckPassword(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string checkSqlCommand = string.Format($"select password from Client where PhoneNumber ='{Login}' ");
            SqlCommand command = new SqlCommand(checkSqlCommand, scon);
            var result = command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string passwordCheck = (string)reader.GetValue("password");
            reader.Close();
            if (result > 0)
            {
                if(passwordCheck == Password)
                    return 1;
                    else return 0;
            }
            else return 0;
                
        }
    }
}
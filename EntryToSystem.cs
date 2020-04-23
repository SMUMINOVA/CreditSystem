using System;
using System.Data;
using System.Data.SqlClient;
namespace FirstProject
{
    public class EntryToSystem : UsersAccount
    {
        public DateTime Birthday{get;set;}
        public string Login{get; set;}
        public string Password{get;set;}
        public const string AdminPassword = "1234";
        //проверка на наличие аккаунта у данного номера
        public int CheckAccount(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string checkSqlCommand = string.Format($"select Password from Client where PhoneNumber ='{Login}' ");
            SqlCommand command = new SqlCommand(checkSqlCommand, scon);
            SqlDataReader reader = command.ExecuteReader();
            string passwordCheck = "";
            while(reader.Read()){
                passwordCheck = (string)reader.GetValue("password");
            }
            reader.Close();
                System.Console.WriteLine(passwordCheck);
                if(passwordCheck != "")
                    return 1;
                else return 0;
        }
        //проверка на верность введения пароля
        public int CheckPassword(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string checkSqlCommand = string.Format($"select Password from Client where PhoneNumber ='{Login}' ");
            SqlCommand command = new SqlCommand(checkSqlCommand, scon);
            SqlDataReader reader = command.ExecuteReader();
            string passwordCheck = "";
            while(reader.Read()){
                passwordCheck = (string)reader.GetValue("Password");
            }
            reader.Close();
                System.Console.WriteLine(passwordCheck);
                if(passwordCheck == Password){
                    string getInfo = string.Format($"select * from Client where PhoneNumber ='{Login}'");
                    while (reader.Read())
                    {
                        Birthday = (DateTime)reader.GetValue("BirthDate");
                        DocumentNo = (string)reader.GetValue("DocumentNo");
                        Name = (string)reader.GetValue("Name");
                        Surname = (string)reader.GetValue("Surname");
                    }
                    reader.Close();
                    return 1;
                }
                else return 0;
                
        }
    }
}
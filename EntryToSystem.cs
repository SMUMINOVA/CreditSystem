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
        public string AdminPassword {get;} = "1234";
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
            string checkSqlCommand = string.Format($"select * from Client where PhoneNumber = '{Login}' ");
            SqlCommand command = new SqlCommand(checkSqlCommand, scon);
            SqlDataReader reader = command.ExecuteReader();
            string passwordCheck = "";
            while(reader.Read()){
                passwordCheck = (string)reader.GetValue("Password");
                DocumentNo = (string)reader.GetValue("DocumentNo");
                Birthday = (DateTime)reader.GetValue("BirthDate");
                Name = (string)reader.GetValue("Name");
                Surname = (string)reader.GetValue("Surname");
                Form.ClientId = int.Parse(reader.GetValue("Id").ToString());
            }
            reader.Close();
                if(passwordCheck == Password){
                    return 1;
                }
                else return 0;
                
        }
    }
}
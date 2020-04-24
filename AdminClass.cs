using System;
using System.Data;
using System.Data.SqlClient;
namespace FirstProject
{
    public class AdminClass
    {
        public UsersForm Form{get;set;}
        public void GetClientsInfo(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string commandText = $"Select * from Client";
                SqlCommand command = new SqlCommand(commandText, scon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine($"Id: {reader.GetValue("Id")}\nИмя: {reader.GetValue("Name")}\nФамилия: {reader.GetValue("Surname")} \nНомер телефона: {reader.GetValue("PhoneNumber")}, \nДата рождения: {reader.GetValue("BirthDate")} \nНомер паспорта: {reader.GetValue("DocumentNo")} \nПароль: {reader.GetValue("Password")}") ;
                }
                reader.Close();
        }
        public void GetRequestsInfo(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string commandText = $"Select * from Request";
                SqlCommand command = new SqlCommand(commandText, scon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine($"Id клиента: {reader.GetValue("Client_Id")}\nДата подачи заявки: {reader.GetValue("dateOf")}\nСрок кредита: {reader.GetValue("PeriodOfCredit")} месяцев, \nСумма кредита: {reader.GetValue("SumOfCredit")}, \nСтатус кредита: {reader.GetValue("StatusOfRequest")}") ;
                }
                reader.Close();
        }
        public void GetRequestById(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string commandText = $"Select * from Request where Client_Id = {Form.ClientId}";
                SqlCommand command = new SqlCommand(commandText, scon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine($"Id клиента: {reader.GetValue("Client_Id")}\nДата подачи заявки: {reader.GetValue("dateOf")}\nСрок кредита: {reader.GetValue("PeriodOfCredit")} месяцев, \nСумма кредита: {reader.GetValue("SumOfCredit")}, \nСтатус кредита: {reader.GetValue("StatusOfRequest")}") ;
                }
                reader.Close();
        }
        
    }
}

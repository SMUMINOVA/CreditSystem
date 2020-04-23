using System;
using System.Data;
using System.Data.SqlClient;
namespace FirstProject
{
    public class UsersAccount
    {
        public EntryToSystem Entry{get; set;}
        public string Name{get;set;}
        public string Surname{get; set;}
        public UsersForm Form{get;set;}

        public int Registration(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string insertSqlCommand = string.Format($"insert into Client([Name],[Surname],[DocumentNo],[PhoneNumber], [password]) Values('{Name}','{Surname}', '{Form.DocumentNo}', '{Entry.Login}', '{Entry.Password}')");
            SqlCommand command = new SqlCommand(insertSqlCommand, scon);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                return 1;
            }
            else return 0;
        }
        public int RequestHistory(){
                const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string commandText = $"Select * from Request where Client_Id = {Form.ClientId}";
                SqlCommand command = new SqlCommand(commandText, scon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string status;
                    if(reader.GetValue("StatusOfRequest") == "Nonsuit") status = "Отказанно";
                    else status = "Подтвержденно";
                    System.Console.WriteLine($"Дата подачи заявки: {reader.GetValue("dateOf")}\nСрок кредита: {reader.GetValue("PeriodOfCredit")} месяцев, \nСумма кредита: {reader.GetValue("SumOfCredit")}, \nСтатус кредита: {status}");
                }
                reader.Close();
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return 1;
                }
                else return 0;
        }
        public int CreateGrafic(){
            string TablesName = Form.RequestId + Name;
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string insertSqlCommand = string.Format($"Create table {TablesName}(id int identity primary key, Date DateTime, Summ int, Status nvarchar null) ");
            SqlCommand command = new SqlCommand(insertSqlCommand, scon);
            var result = command.ExecuteNonQuery();
            if (result > 0)
                {
                    return 1;
                }
                else return 0;
        }
        
    }
}
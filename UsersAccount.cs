using System;
using System.Data;
using System.Data.SqlClient;
namespace FirstProject
{
    public class UsersAccount: AdminClass
    {
        public EntryToSystem Entry{get; set;}
        public string Name{get;set;}
        public string Surname{get; set;}

        public string DocumentNo{get; set;}

        public int Registration(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string insertSqlCommand = string.Format($"insert into Client([Name],[Surname],[DocumentNo],[PhoneNumber], [password], [BirthDate]) Values('{Name}','{Surname}', '{Form.DocumentNo}', '{Entry.Login}', '{Entry.Password}', '{Form.Birthday}')");
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
                int idReq = 0;
                string commandText = $"Select * from Request where Client_Id = {Form.ClientId}";
                SqlCommand command = new SqlCommand(commandText, scon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine($"Дата подачи заявки: {reader.GetValue("dateOf")}\nСрок кредита: {reader.GetValue("PeriodOfCredit")} месяцев, \nСумма кредита: {reader.GetValue("SumOfCredit")}, \nСтатус кредита: {reader.GetValue("StatusOfRequest")}");
                    idReq = (int)reader.GetValue("Id");
                }
                reader.Close();
                if(idReq == 0)
                   return 0;
                else return 1;
        }
        public int CreateGrafic(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string name = Name + Form.RequestId;
            string insertSqlCommand = string.Format($"create table {name}(id int identity primary key, Date DateTime, Summ float, Status nvarchar(30) null) ");
            SqlCommand command = new SqlCommand(insertSqlCommand, scon);
            try{
                command.ExecuteNonQuery();
                scon.Close();
                return 1;
            }
            catch{
                scon.Close();
                return 0;
            }
        }
        public void SetGraficInfo(){
            double summ = Form.CreditSumm/Form.PeriodOfCredit;
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            for (int i = 0; i < Form.PeriodOfCredit; i++){
                string insertSqlCommand = string.Format($"insert into {Name + Form.RequestId}([Date],[Summ], [Status]) Values('{Form.DateOfRequest.AddMonths(i+1)}',{summ}, 'Wait for payment')");
                SqlCommand command = new SqlCommand(insertSqlCommand, scon);
                command.ExecuteNonQuery();
        }
        }
        public void GetGraficInfo(){
                const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string commandText = $"Select * from {Name + Form.RequestId}";
                SqlCommand command = new SqlCommand(commandText, scon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine($"Дата оплаты: {reader.GetValue("Date")}\nСумма: {reader.GetValue("Summ")}\nСтатус: {reader.GetValue("Status")}");
                }
                reader.Close();
        }
    }
}
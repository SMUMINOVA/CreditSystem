using System;
using System.Data;
using System.Data.SqlClient;
namespace FirstProject
{
    public class AdminClass
    {
        public int GetClientsInfo(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
                SqlConnection scon = new SqlConnection(conString);
                scon.Open();
                string commandText = $"Select * from Client";
                SqlCommand command = new SqlCommand(commandText, scon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine($"Дата подачи заявки: {reader.GetValue("dateOf")}\nСрок кредита: {reader.GetValue("PeriodOfCredit")} месяцев, \nСумма кредита: {reader.GetValue("SumOfCredit")}, \nСтатус кредита: {reader.GetValue("StatusOfRequest")}");
                }
                reader.Close();
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return 1;
                }
                else return 0;
        }
    }
}
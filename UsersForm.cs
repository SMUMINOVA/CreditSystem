using System;
using System.Data;
using System.Data.SqlClient;
namespace FirstProject
{
    public class UsersForm
    {
        public string Gender{get; set;}
        public string FamilyStatus{get; set;}
        public int Age{get; set;}
        public string CityZone{get; set;}
        public int CreditsHistory{get; set;}
        public int OutstandingCredits{get; set;}
        public string GoalOfCredit{get; set;}
        public int PeriodOfCredit{get; set;}
        public int Salary{get;set;}
        public int CreditSumm{get; set;}
        public int ClientId{get;set;}
        public int SendingDataToService(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string insertSqlCommand = string.Format($"insert into Request([FirstName],[MiddleName],[LastName],[BirthDate]) Values('{FirstName}','{MiddleName}', '{LastName}', '{BirthDate}')");
            SqlCommand command = new SqlCommand(insertSqlCommand, scon);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                System.Console.WriteLine("Insert command successfull!!!");
            }
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
namespace FirstProject
{
    public class UsersForm: EntryToSystem
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
        public DateTime DateOfRequest{get;set;}
        public string RequestStatus{get;set;}
        public int RequestId{get;set;}
        //получение клиентского id для дальнейших действий
        public void GetClientId(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string checkSqlCommand = string.Format($"select Id from Client where PhoneNumber = '{Login}' ");
            SqlCommand command = new SqlCommand(checkSqlCommand, scon);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read()){
                ClientId = (int)reader.GetValue(0);
            }
            reader.Close();
        }
        public void GetRequestId(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            string checkSqlCommand = string.Format($"select Id from Request where Client_Id = {ClientId} ");
            SqlCommand command = new SqlCommand(checkSqlCommand, scon);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read()){
            RequestId = (int)reader.GetValue("Id");
            }
            reader.Close();
        }
        public int SendingDataToService(){
            const string conString = @"Data source=localhost; Initial catalog = Test; user id = sa;password=S1806Kh2111";
            SqlConnection scon = new SqlConnection(conString);
            scon.Open();
            GetClientId();
            string insertSqlCommand = string.Format($"insert into Request([Age],[CityZone],[Client_Id],[CreditHistory], [dateOf], [DocumentNoOfClient], [FamilyStatus], [Gender], [GoalOfCredit], [NumberOfOutstandingCredits], [PeriodOfCredit], [SumOfCredit], [StatusOfRequest]) Values('{Age}','{CityZone}', '{ClientId}', '{CreditsHistory}', '{DateOfRequest}','{DocumentNo}', '{FamilyStatus}', '{Gender}', '{GoalOfCredit}', '{OutstandingCredits}', '{PeriodOfCredit}', '{CreditSumm}', '{RequestStatus}')");
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
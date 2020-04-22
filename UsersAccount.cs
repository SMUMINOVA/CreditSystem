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
            string insertSqlCommand = string.Format($"insert into Client([Name],[Surname],[DocumentNo],[PhoneNumber], [password]) Values('{Name}','{Surname}', '{DocumentNo}', '{Entry.Login}', '{Entry.Password}')");
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
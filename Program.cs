using System;
using System.Data;
using System.Data.SqlClient;
namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            UsersAccount acc = new UsersAccount();
            acc.Entry = new EntryToSystem();
            System.Console.WriteLine("Здравствуйте!");
            startRegistration:
            System.Console.WriteLine("Для начала работы вам необходимо войти в свой аккаунт, или, если у вас нет аккаунта, вы можете зарегистрироваться.");
            System.Console.WriteLine("1. Зарегистрироваться\n2. Войти в существующий аккаунт\n3. Выход");
            switch(Console.ReadLine()){
                case "1":{
                    System.Console.Write("Имя: ");
                    acc.Name = Console.ReadLine();
                    System.Console.Write("Фамилия: ");
                    acc.Surname = Console.ReadLine();
                    System.Console.Write("Номер паспорта: ");
                    acc.DocumentNo = Console.ReadLine();
                    System.Console.Write("Номер телефона: ");
                    acc.Entry.Login = Console.ReadLine();
                    System.Console.Write("Пароль: ");
                    acc.Entry.Password = Console.ReadLine();
                    if(acc.Entry.CheckAccount() == 1){
                        System.Console.WriteLine("На этом номере уже зарегистрирован аккаунт. Попробуйте снова.");
                        goto startRegistration;
                    }
                    else{
                        if(acc.Registration() == 1){
                            Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.WriteLine("Вы были успешно зарегистрированны");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("Произошла ошибка! Попробуйте снова");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto startRegistration;
                        }
                    }
                } ;break;
                case "2":{
                    System.Console.Write("Номер телефона: ");
                    acc.Entry.Login = Console.ReadLine();
                    System.Console.WriteLine("Пароль: ");
                    acc.Entry.Password = Console.ReadLine();
                    if(acc.Entry.CheckPassword() == 1){
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Вы успешно вошли в систему");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("Произошла ошибка! Попробуйте снова");
                            Console.ForegroundColor = ConsoleColor.White;
                            goto startRegistration;
                        }
                }; break;
                case "3": goto end;
                default: Console.ForegroundColor = ConsoleColor.Red;
                         System.Console.WriteLine("Произошла ошибка! Попробуйте снова");
                         Console.ForegroundColor = ConsoleColor.White;
                         goto startRegistration;
            }
            






            end :
            System.Console.WriteLine("Пока");
        }
    }
}

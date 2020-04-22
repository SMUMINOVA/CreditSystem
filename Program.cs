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
            acc.Form = new UsersForm();
            System.Console.WriteLine("Добро пожаловать в кредитную систему банка Алиф!");
            System.Console.WriteLine("Выберите одно из следующих действий: ");
            System.Console.WriteLine("1. Подать заявку на кредит.\n 2. История заявок");
            switch(Console.ReadLine()){
                case "1": {
                    int counter = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Заявка");
                    Console.ForegroundColor = ConsoleColor.White;
                    gender: 
                    System.Console.WriteLine("Пол:\n1.мужской\n2.женский");
                    switch(Console.ReadLine()){
                        case "1": {
                            acc.Form.Gender = "male";
                            counter++;
                        };break;
                        case "2":{ 
                            counter += 2;
                            acc.Form.Gender = "female";
                        }; break;
                        default: 
                         Console.ForegroundColor = ConsoleColor.Red;
                         System.Console.WriteLine("Произошла ошибка! Попробуйте снова");
                         Console.ForegroundColor = ConsoleColor.White;
                         goto gender;
                    }
                    family:
                    System.Console.WriteLine("Семейное положение:\n1. Холост\n2. Семьянин\n3. В разводе\n4. Вдовец/вдова");
                    switch(Console.ReadLine()){
                        case "1": {
                            counter++;
                            acc.Form.FamilyStatus = "Single";
                        };break;
                        case "2": {
                            acc.Form.FamilyStatus = "married";
                            counter +=2;
                        }; break;
                        case "3": {
                            counter ++;
                            acc.Form.FamilyStatus = "divorced";
                        };break;
                        case "4": {
                            counter +=2;
                            acc.Form.FamilyStatus = "widow/er";
                        }; break;
                        default: 
                         Console.ForegroundColor = ConsoleColor.Red;
                         System.Console.WriteLine("Произошла ошибка! Попробуйте снова");
                         Console.ForegroundColor = ConsoleColor.White;
                        goto family;
                    }
                    System.Console.Write("Возраст: ");
                    acc.Form.Age = int.Parse(Console.ReadLine());
                    if(acc.Form.Age > 25 && acc.Form.Age <= 35) counter++;
                    else if(acc.Form.Age <= 62) counter +=2;
                    else{
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Произошла ошибка! Попробуйте снова");
                        Console.ForegroundColor = ConsoleColor.White;
                    }                       
                    city: 
                    System.Console.WriteLine("Гражданство: \n1. Таджикистан\n2. Другая страна");
                    switch(Console.ReadLine()){
                        case "1": counter++; break;
                        case "2": ; break;
                        default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Произошла ошибка! Попробуйте снова");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto city;
                    }
                    System.Console.WriteLine("Заработная плата: ");
                    acc.Form.Salary = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Сумма кредита: ");
                    acc.Form.CreditSumm = int.Parse(Console.ReadLine());
                    double percent = acc.Form.CreditSumm * 100 / acc.Form.Salary;
                    if(percent <= 80) counter += 4;
                    else if(percent <= 150) counter += 3;
                    else if(percent <= 250) counter += 2;
                    else counter ++;
                    System.Console.WriteLine("Кредитная истоия(количество закрытых кредитов): ");
                    acc.Form.CreditsHistory = int.Parse(Console.ReadLine());
                    if(acc.Form.CreditsHistory >= 3) counter += 2;
                    else if(acc.Form.CreditsHistory > 0) counter ++;
                    else counter--;
                    System.Console.WriteLine("Количество просрочек в кредитной истории: ");
                    acc.Form.OutstandingCredits = int.Parse(Console.ReadLine());
                    if(acc.Form.OutstandingCredits > 7) counter -= 3;
                    else if (acc.Form.OutstandingCredits > 4) counter -= 2;
                    else if (acc.Form.OutstandingCredits == 4) counter --;
                    goal:
                    System.Console.WriteLine("Цель кредита: \n1. Бытовая техника\n2. Ремонт\n3. Телефон\n4. Прочее");
                    switch(Console.ReadLine()){
                        case "1": {
                            acc.Form.GoalOfCredit = "appliences";
                            counter += 2;
                        };break;
                        case "2": {
                            acc.Form.GoalOfCredit = "Repair";
                            counter += 1;
                        };break;
                        case "3": {
                            acc.Form.GoalOfCredit = "Phone";
                        };break;
                        
                        case "4": {
                            acc.Form.GoalOfCredit = "other";
                            counter -= 1;
                        };break;
                        default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Произошла ошибка! Попробуйте снова");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto goal;
                    }
                    System.Console.WriteLine("Срок кредита: ");
                    acc.Form.PeriodOfCredit = int.Parse(Console.ReadLine());
                    counter ++;
                    if(counter <= 11){
                        System.Console.WriteLine("К сожалению, банк Алиф не может предоставить вам возможность взятия кредита при таких условиях.");
                    }
                    else{
                        
                    }


                }; break;







            }






            end :
            System.Console.WriteLine("Пока");
        }
    }
}

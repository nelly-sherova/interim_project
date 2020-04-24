using System;
using System.Data;
using System.Data.SqlClient;

namespace Project_1
{
  class ApplicationHistory
  {
    public string otvet = " ";
    const string connectionString = @"Data source=NILUFARSHEROVA; Initial catalog=ProjectAlifDB; Integrated Security = True";
    public void ApplicHistory()
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      string AdminKey = "ad0010", key;
      Console.WriteLine("Для доступа к системе введите пароль админа: ");
      key = Console.ReadLine();
      if (key==AdminKey)
      {
         bool working = true;
         while (working)
         {
             Console.WriteLine("Выберете действие \n1->Вывести историю всех регистраций, \n2->Вывести историю всех анкетирований \n3->Вывести историю всех заявок, \n4->Вывести все ответы,\n 5->Выход \n");
             int index = Convert.ToInt32(Console.ReadLine());
             switch (index)
             {
                 case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("История регистраций: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string sqlExpression1 = "SELECT * FROM Registration";
                    using (SqlConnection connection1 = new SqlConnection(connectionString))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(sqlExpression1, connection1);
                        SqlDataReader reader  = command1.ExecuteReader();
                        while (reader.Read()) Console.WriteLine($"ID: {reader.GetValue(0)}, Имя:{reader.GetValue(1)} | Фамилия:{reader.GetValue(2)} | Отчество:{reader.GetValue(3)} | Логин:{reader.GetValue(4)} | Дата рождения:{reader.GetValue(5)}| Пол: {reader.GetValue(6)} | Гражданство: {reader.GetValue(7)} | Дата выдачи паспорта: {reader.GetValue(8)} | Дата истечения срока действия паспорта: {reader.GetValue(9)} | Адрес: {reader.GetValue(10)} | Орган, выдавший паспорт {reader.GetValue(11)} | Серия паспорта: {reader.GetValue(12)}");
                    }
                 break;
                 case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("История анкетирований: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string sqlExpression2 = "SELECT * FROM Anketa";
                    using (SqlConnection connection1 = new SqlConnection(connectionString))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(sqlExpression2, connection1);
                        SqlDataReader reader  = command1.ExecuteReader();
                        while (reader.Read()) Console.WriteLine($"ID: {reader.GetValue(0)}, Имя:{reader.GetValue(1)} | Фамилия: {reader.GetValue(2)} | Отчество: {reader.GetValue(3)} | Возраст: {reader.GetValue(4)} | Семейное положение:  {reader.GetValue(5)}");
                    }
                 break;
                 case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("История заявок: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string sqlExpression4 = "SELECT * FROM AplicationForCredit";
                    using (SqlConnection connection1 = new SqlConnection(connectionString))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(sqlExpression4, connection1);
                        SqlDataReader reader  = command1.ExecuteReader();
                        while (reader.Read()) Console.WriteLine($"ID: {reader.GetValue(0)}, Имя:{reader.GetValue(1)} | Фамилия: {reader.GetValue(2)} | Отчество: {reader.GetValue(3)} | Сумма кредита: {reader.GetValue(4)} | Доход:  {reader.GetValue(5)}| Кредитная история (закрытые кредиты): {reader.GetValue(6)} | Просрочка в кредитной истории {reader.GetValue(7)} | Цель кредита: {reader.GetValue(8)} ");
                    }
                 break;
                 case  4:
                   Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("История ответов: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string sqlExpression3 = "SELECT * FROM Answer";
                    using (SqlConnection connection1 = new SqlConnection(connectionString))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(sqlExpression3, connection1);
                        SqlDataReader reader  = command1.ExecuteReader();
                        while (reader.Read()) Console.WriteLine($"ID: {reader.GetValue(0)}, | ответ  {reader.GetValue(1)} | имя: {reader.GetValue(2)} | фамилия: {reader.GetValue(3)} | отчество: {reader.GetValue(4)}");
                    }
                 break;
                 case 5:
                    working = false;
                 break;
                 default:
                    Console.WriteLine("Неправильная команда!");
                break;
             }

         }
         
      }
      else
      {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write("Неправильный пароль!");
          Console.ForegroundColor = ConsoleColor.White;
      }
     

    }
  }
}

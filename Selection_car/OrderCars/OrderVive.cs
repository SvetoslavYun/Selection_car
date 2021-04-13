using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Windows;

namespace Selection_car
{
    public class OrderVive
    {
        public int OrderVive_Id { get; set; }
        public int CountCars { get; set; }
        public String Name { get; set; }

        public String RadioVive { get; set; }

        static SQLiteConnection connection;

        public OrderVive()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        static OrderVive()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }


        public override string ToString()
        {
            return String.Format($"{CountCars}");
        }

        public static IEnumerable<OrderVive> GetAllVive()
        {
            var commandString = "Select * from OrderVives ";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    var orderVive_Id = reader.GetInt32(0);
                    var countCars = reader.GetInt32(1);
                    var name = reader.GetString(2);
                    var radioVive = reader.GetString(3);
                    var orderVive = new OrderVive
                    {
                        OrderVive_Id = orderVive_Id,
                        CountCars = countCars,
                        Name=name,
                        RadioVive = radioVive
                    };
                    yield return orderVive;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderVive> GetAl()
        {
            var commandString = "Select  SUM (CountCars) from OrderVives";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    var countCars = reader.GetInt32(0);
                    var orderVive = new OrderVive
                    {

                        CountCars = countCars,
                    };
                    yield return orderVive;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderVive> GetAl2()
        {
            var commandString = "Select  CountCars=0 from OrderVives";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    var countCars = reader.GetInt32(0);
                    var orderVive = new OrderVive
                    {

                        CountCars = countCars,
                    };
                    yield return orderVive;
                }
            };
            connection.Close();
        }

        public void Insert()
        {
            var commandString = "INSERT INTO OrderVives (CountCars, Name, RadioVive)" + "VALUES (@countCars, @name, @radioVive)";
            SQLiteCommand insertCommand = new SQLiteCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SQLiteParameter[]
                {
                  new SQLiteParameter("countCars", CountCars),
                  new SQLiteParameter("name", Name),
                  new SQLiteParameter("radioVive", RadioVive),
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update()
        {          
                var commandString = "UPDATE OrderVives SET CountCars = @countCars WHERE(OrderVive_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
                updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("countCars",CountCars),
                         new SQLiteParameter("id",OrderVive_Id ),

                });
                connection.Open();
                updateCommand.ExecuteNonQuery();
                connection.Close();           
        }

        public static void Delete(int id)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var commandString = "DELETE FROM OrderVives WHERE(OrderVive_Id = @id)";
                SQLiteCommand deleteCommand = new SQLiteCommand(commandString, connection);
                deleteCommand.Parameters.AddWithValue("id", id);
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Delete2()
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var commandString = "DELETE FROM OrderVives WHERE Name in (Select Name from OrderVives)";
                SQLiteCommand deleteCommand = new SQLiteCommand(commandString, connection);               
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static OrderVive GetVive(string Vive)
        {
            foreach (var vive in GetAllVive())
            {
                if (vive.RadioVive == Vive)
                    return vive;
            }
            return null;
        }
    }
}




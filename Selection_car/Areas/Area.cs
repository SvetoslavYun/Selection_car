using Selection_car.Areas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Windows;

namespace Selection_car
{
    public class Area
    {
        public int Areas_Id { get; set; }
        public String Are { get; set; }
        public String Cities { get; set; }
        public decimal Distance { get; set; }
        public String Days { get; set; }
        public decimal BelTol { get; set;}

        static SQLiteConnection connection;
        public Area()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        static Area()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        public static IEnumerable<Area> GetAllArea()
        {
            var commandString = "Select * From Areas";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var areas_Id = reader.GetInt32(0);
                    var are = reader.GetString(1);
                    var cities = reader.GetString(2);                
                    var distance = reader.GetDecimal(3);
                    var days = reader.GetString(4);
                    var belTol = reader.GetDecimal(5);
                    var area = new Area
                    {
                        Areas_Id = areas_Id,
                        Are=are,
                        Cities = cities,
                        Distance = distance,
                        Days=days,
                        BelTol = belTol
                    };
                    yield return area;
                }
            };
            connection.Close();
        }

       

        public static IEnumerable<Area> Area_Search()
        {
            var commandString = "Select * from Areas Where (Are ='" + AreasWindow.name + "')";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var areas_Id = reader.GetInt32(0);
                    var are = reader.GetString(1);
                    var cities = reader.GetString(2);
                    var distance = reader.GetDecimal(3);
                    var days = reader.GetString(4);
                    var belTol = reader.GetDecimal(5);
                    var area = new Area
                    {
                        Areas_Id = areas_Id,
                        Are=are,
                        Cities = cities,
                        Distance = distance,
                        Days=days,
                        BelTol = belTol
                    };
                    yield return area;
                }
            };
            connection.Close();
        }

        internal static object GetAllArea(object text)
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            var commandString = "INSERT INTO Areas (Are, Cities, Distance, Days, BelTol)" + "VALUES (@are, @cities, @distance, @days, @belTol)";
            SQLiteCommand insertCommand = new SQLiteCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SQLiteParameter[]
                {
                         new SQLiteParameter("are", Are),
                         new SQLiteParameter("cities", Cities),
                         new SQLiteParameter("distance", Distance),
                         new SQLiteParameter("days", Days),
                         new SQLiteParameter("belTol", BelTol)
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Insert2()
        {
            var commandString = "INSERT INTO Areas (Are, Cities, Distance, Days, BelTol)" + "VALUES (@are, @cities, @distance, @days, @belTol)";
            SQLiteCommand insertCommand = new SQLiteCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SQLiteParameter[]
                {
                         new SQLiteParameter("are", Are),
                         new SQLiteParameter("cities", Cities),
                         new SQLiteParameter("distance", Distance),
                         new SQLiteParameter("days", Days),
                         new SQLiteParameter("belTol", BelTol)
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }
        public void Update()
        {
            var commandString = "UPDATE Areas SET Are=@are, Cities = @cities, Distance = @distance, Days = @days, BelTol=@belTol WHERE(Areas_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("Id",Areas_Id ),
                       new SQLiteParameter("are",Are ),
                       new SQLiteParameter("cities", Cities),
                       new SQLiteParameter("distance", Distance),
                       new SQLiteParameter("days", Days),
                       new SQLiteParameter("belTol", BelTol)
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Clear()
        {
            this.Areas_Id = 0;
            this.Are = "";
            this.Cities = "";
            this.Distance = 0;
            this.Days = "";
            this.BelTol = 0;

        }

        public static void Delete(int id)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var commandString = "DELETE FROM Areas WHERE(Areas_Id = @id)";
                SQLiteCommand deleteCommand = new SQLiteCommand(commandString, connection);
                deleteCommand.Parameters.AddWithValue("id", id);
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static Area GetArea(String are)
        {
            foreach (var area in GetAllArea())
            {
                if (area.Are == are)
                    return area;
            }
            return null;
        }

    }
}

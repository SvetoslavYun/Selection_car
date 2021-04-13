using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Windows;

namespace Selection_car
{
    public class User
    {
        public int User_Id { get; set; } /*Id Ппользователя*/
        public String Name { get; set; }//имя пользователя
        public String Password { get; set; }//пароль
        public String Type { get; set; }

        static SQLiteConnection connection;

        public User()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        static User()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        public static IEnumerable<User> GetAllUser()
        {
            var commandString = "SELECT * FROM Users";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var user_id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var password = reader.GetString(2);
                    var type = reader.GetString(3);
                    var user = new User
                    {
                        User_Id = user_id,
                        Name = name,
                        Password = password,
                        Type=type
                    };
                    yield return user;
                }
            };
            connection.Close();
        }

        public static IEnumerable<User> User_Search()
        {
            var commandString = "SELECT * FROM Users Where(Name ='" + MainWindowUser.name + "' And Password ='" + MainWindowUser.password + "')";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var user_id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var password = reader.GetString(2);
                    var user = new User
                    {
                        User_Id = user_id,
                        Name = name,
                        Password = password,
                    };
                    yield return user;
                }
            };
            connection.Close();
        }

        public static IEnumerable<User> User_Search2()
        {
            var commandString = "SELECT * FROM Users";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var user_id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var password = reader.GetString(2);
                    var user = new User
                    {
                        User_Id = user_id,
                        Name = name,
                        Password = password,
                    };
                    yield return user;
                }
            };
            connection.Close();
        }

        public static IEnumerable<User> User_Search3()
        {
            var commandString = "SELECT * FROM Users";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var user_id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var password = reader.GetString(2);
                    var user = new User
                    {
                        User_Id = user_id,
                        Name = name,
                        Password = password,
                    };
                    yield return user;
                }
            };
            connection.Close();
        }
        public void Insert()
        {
            var commandString = "INSERT INTO Users (Name, Password, Type)" + "VALUES (@name, @password, @type)";
            SQLiteCommand insertCommand = new SQLiteCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SQLiteParameter[]
                {
                       new SQLiteParameter("name", Name),
                       new SQLiteParameter("password", Password),
                       new SQLiteParameter("type", Type),
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }




        public void Update()
        {
            var commandString = "UPDATE Users SET Name = @name, Password = @password, Type=@type WHERE(User_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("name", Name),
                       new SQLiteParameter("password", Password),
                       new SQLiteParameter("Id",User_Id ),
                       new SQLiteParameter("type", MainWindowUser.name2),
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
                var commandString = "DELETE FROM Users WHERE(User_id = @id) AND User_id != 1";
                SQLiteCommand deleteCommand = new SQLiteCommand(commandString, connection);
                deleteCommand.Parameters.AddWithValue("id", id);
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Clear()
        {
            this.Name = "";
            this.Password = "";
            this.Type = "";
        }

        public static User GetUser(String name, String password)
        {
            foreach (var user in User_Search())
            {
                if (user.Name == name && user.Password == password)
                    return user;


            }

            return null;
        }

        public static User GetUser2(int id)
        {
            foreach (var user in User_Search3())
            {
                if (user.User_Id == id)
                    return user;


            }

            return null;
        }

    }
}




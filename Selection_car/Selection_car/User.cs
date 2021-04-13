using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace Selection_car
{
    public class User
    {
        public int User_Id { get; set; } /*Id Ппользователя*/
        public String Name { get; set; }//имя пользователя
        public String Password { get; set; }//пароль

        static SqlConnection connection;

        public User()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SqlConnection(connString);
        }

        static User()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SqlConnection(connString);
        }

        public override string ToString()
        {
            return String.Format($"id={User_Id};      Имя пользователя: {Name};      Пароль: {Password}");
        }

        public static IEnumerable<User> GetAllUser()
        {
            var commandString = "SELECT * FROM Users";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
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

        public static IEnumerable<User> User_Search()
        {
            var commandString = "SELECT * FROM Users Where(User_Id=" + MainWindow2._id + " or Name = N'" + MainWindow2.name + "')";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
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
            var commandString = "INSERT INTO Users (Name, Password)" + "VALUES (@name, @password)";
            SqlCommand insertCommand = new SqlCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[]
                {
                       new SqlParameter("name", Name),
                       new SqlParameter("password", Password),
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }


        public static User GetName(String name)
        {
            foreach (var user in GetAllUser())        /*Поиск по id*/
            {
                if (user.Name == name)
                    return user;
            }
            return null;
        }

        public void Update()
        {
            var commandString = "UPDATE Users SET Name = @name, Password = @password WHERE(User_Id = @id)";
            SqlCommand updateCommand = new SqlCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SqlParameter[] {
                       new SqlParameter("name", Name),
                       new SqlParameter("password", Password),
                       new SqlParameter("Id",User_Id ),
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
                var commandString = "DELETE FROM Users WHERE(User_id = @id)";
                SqlCommand deleteCommand = new SqlCommand(commandString, connection);
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
        }
    }
}




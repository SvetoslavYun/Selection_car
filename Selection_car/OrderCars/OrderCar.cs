using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Windows;

namespace Selection_car
{
    public class OrderCar
    {
        public int OrderCar_Id { get; set; }
        public DateTime Data { get; set; }
        public string Data2 { get; set; }
        public String Are { get; set; }
        public int Car_Id { get; set; }
        public int Company_Id { get; set; }
        public int CountCars { get; set; }
        public String Name { get; set; }
        public String Namee { get; set; }
        public String Driver { get; set; }
        public String Brand { get; set; }
        public String Number { get; set; }
        public String Type { get; set; }
        public decimal Shops { get; set; }
        public decimal Tonnage { get; set; }
        public decimal Mileage { get; set; }
        public decimal Earned { get; set; }
        public decimal Expenses { get; set; }
        public decimal Profit { get; set; }
        public decimal Freight { get; set; }
        public decimal Profitability { get; set; }

        static SQLiteConnection connection;

        public OrderCar()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        static OrderCar()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SQLiteConnection(connString);
        }

        public override string ToString()
        {
            return String.Format($"{Car_Id}");
        }
             
        public static IEnumerable<OrderCar> GetAllOrder_13()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data  BETWEEN '" + MainWindowOrder.year + "-" + MainWindowOrder.month + "-" + MainWindowOrder.day + "%' AND '" + MainWindowOrder.year2 + "-" + MainWindowOrder.month2 + "-" + MainWindowOrder.day2 + "%' " + MainWindowOrder.Companyname + " " + MainWindowOrder.Drivername + " and O.Are !='Минск' and C.Type!='Сборная' and C.Type!='Кондитерская' ";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var orderCar = new OrderCar
                    {
                        //Data = data,
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }
        public static IEnumerable<OrderCar> GetAllOrder_12()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data  BETWEEN '" + MainWindowOrder.year + "-" + MainWindowOrder.month + "-" + MainWindowOrder.day + "%' AND '" + MainWindowOrder.year2 + "-" + MainWindowOrder.month2 + "-" + MainWindowOrder.day2 + "%' " + MainWindowOrder.Companyname + " " + MainWindowOrder.Drivername + " and C.Type='Сборная' ";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var orderCar = new OrderCar
                    {
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder_11()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data  BETWEEN '" + MainWindowOrder.year + "-" + MainWindowOrder.month + "-" + MainWindowOrder.day + "%' AND '" + MainWindowOrder.year2 + "-" + MainWindowOrder.month2 + "-" + MainWindowOrder.day2 + "%' " + MainWindowOrder.Companyname + " " + MainWindowOrder.Drivername + " and C.Type='Кондитерская'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //var data = reader.GetString(0);
                    var car_id = reader.GetInt32(0);
                    //var name = reader.GetString(1);
                    var orderCar = new OrderCar
                    {
                        //Data = data,
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder_10()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data  BETWEEN '" + MainWindowOrder.year + "-" + MainWindowOrder.month + "-" + MainWindowOrder.day + "%' AND '" + MainWindowOrder.year2 + "-" + MainWindowOrder.month2 + "-" + MainWindowOrder.day2 + "%' " + MainWindowOrder.Companyname + " " + MainWindowOrder.Drivername + " and C.Type='Хлебная' and O.Are='Минск'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var orderCar = new OrderCar
                    {
                        //Data = data,
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }
        public static IEnumerable<OrderCar> GetAllOrder_8()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, O.Data2, O.Are, C.Car_Id, C.Company_Id, O.Driver, C.Brand, C.Number, C.Type, Co.Name from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data  BETWEEN '" + MainWindowOrder.year + "-" + MainWindowOrder.month + "-" + MainWindowOrder.day + "%' AND '" + MainWindowOrder.year2 + "-" + MainWindowOrder.month2 + "-" + MainWindowOrder.day2 + "%' " + MainWindowOrder.Companyname + " " + MainWindowOrder.Drivername + " ORDER BY O.Data ASC";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetDateTime(1);
                    var data2 = reader.GetString(2);
                    var are = reader.GetString(3);
                    var car_id = reader.GetInt32(4);
                    var company_Id = reader.GetInt32(5);
                    var driver = reader.GetString(6);
                    var brand = reader.GetString(7);
                    var number = reader.GetString(8);
                    var type = reader.GetString(9);
                    var name = reader.GetString(10);
                    var orderCar = new OrderCar
                    {
                        OrderCar_Id = orderCar_Id,
                        Data = data,
                        Data2 = data2,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Are = are,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }
        public static IEnumerable<OrderCar> GetAllOrder_7()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' and C.Company_Id=" + MainWindowOrder._companyId2 + " and C.Type='Хлебная' and O.Are='Минск'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var orderCar = new OrderCar
                    {
                        //Data = data,
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }
        public static IEnumerable<OrderCar> GetAllOrder_6()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' and C.Company_Id=" + MainWindowOrder._companyId2 + " and C.Type='Кондитерская'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var orderCar = new OrderCar
                    {
                        //Data = data,
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }
        public static IEnumerable<OrderCar> GetAllOrder_5()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' and C.Company_Id=" + MainWindowOrder._companyId2 + " and C.Type='Сборная'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var orderCar = new OrderCar
                    {
                        //Data = data,
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder_4()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' and C.Company_Id=" + MainWindowOrder._companyId2 + " and O.Are !='Минск' and C.Type!='Сборная' and C.Type!='Кондитерская'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var orderCar = new OrderCar
                    {
                        //Data = data,
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder_3()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' and O.Are !='Минск' and C.Type!='Сборная'and C.Type!='Кондитерская' ";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var orderCar = new OrderCar
                    {
                        //Data = data,
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }
        public static IEnumerable<OrderCar> GetAllOrder_2()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' and C.Type='Сборная' ";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var orderCar = new OrderCar
                    {
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder_1()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' and C.Type='Кондитерская'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //var data = reader.GetString(0);
                    var car_id = reader.GetInt32(0);
                    //var name = reader.GetString(1);
                    var orderCar = new OrderCar
                    {
                        //Data = data,
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder0()
        {
            var commandString = "Select count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' and C.Type='Хлебная' and O.Are='Минск'";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(0);
                    var orderCar = new OrderCar
                    {
                        //Data = data,
                        Car_Id = car_id,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder1()
        {
            var commandString = "Select Co.Name, count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' GROUP BY Co.Name ";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(1);
                    var name = reader.GetString(0);
                    var orderCar = new OrderCar
                    {
                        Car_Id = car_id,
                        Name = name,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder2()
        {
            var commandString = "Select Co.Name, count (C.Car_Id) from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data  BETWEEN '" + MainWindowOrder.year + "-" + MainWindowOrder.month + "-" + MainWindowOrder.day + "%' AND '" + MainWindowOrder.year2 + "-" + MainWindowOrder.month2 + "-" + MainWindowOrder.day2 + "%' " + MainWindowOrder.Companyname + " " + MainWindowOrder.Drivername + " GROUP BY Co.Name ";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var car_id = reader.GetInt32(1);
                    var name = reader.GetString(0);
                    var orderCar = new OrderCar
                    {
                        Car_Id = car_id,
                        Name = name,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }
        public static IEnumerable<OrderCar> GetAllOrder()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, O.Data2, O.Are, C.Car_Id, C.Company_Id, O.Driver, C.Brand, C.Number, C.Type, Co.Name from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' ORDER BY Co.Name ASC";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetDateTime(1);
                    var data2 = reader.GetString(2);
                    var are = reader.GetString(3);
                    var car_id = reader.GetInt32(4);
                    var company_Id = reader.GetInt32(5);
                    var driver = reader.GetString(6);
                    var brand = reader.GetString(7);
                    var number = reader.GetString(8);
                    var type = reader.GetString(9);
                    var name = reader.GetString(10);
                    var orderCar = new OrderCar
                    {
                        OrderCar_Id = orderCar_Id,
                        Data = data,
                        Data2=data2,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Are = are,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder3()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, O.Data2, O.Are, C.Car_Id, C.Company_Id, O.Driver, C.Brand, C.Number, C.Type, Co.Name from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' AND (Co.Name ='" + MainWindowOrder.CompanyName + "')";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetDateTime(1);
                    var data2 = reader.GetString(2);
                    var are = reader.GetString(3);
                    var car_id = reader.GetInt32(4);
                    var company_Id = reader.GetInt32(5);
                    var driver = reader.GetString(6);
                    var brand = reader.GetString(7);
                    var number = reader.GetString(8);
                    var type = reader.GetString(9);
                    var name = reader.GetString(10);
                    var orderCar = new OrderCar
                    {
                        OrderCar_Id = orderCar_Id,
                        Data = data,
                        Data2 = data2,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Are = are,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder4()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, O.Data2, O.Are, C.Car_Id, C.Company_Id, O.Driver, C.Brand, C.Number, C.Type, Co.Name from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data2='" + MainWindowOrder.datatime + "' and C.Company_Id=" + MainWindowOrder._id + " ORDER BY Co.Name ASC";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetDateTime(1);
                    var data2 = reader.GetString(2);
                    var are = reader.GetString(3);
                    var car_id = reader.GetInt32(4);
                    var company_Id = reader.GetInt32(5);
                    var driver = reader.GetString(6);
                    var brand = reader.GetString(7);
                    var number = reader.GetString(8);
                    var type = reader.GetString(9);
                    var name = reader.GetString(10);
                    var orderCar = new OrderCar
                    {
                        OrderCar_Id = orderCar_Id,
                        Data = data,
                        Data2 = data2,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Are = are,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }
        public void Insert()
        {
            var commandString = "INSERT INTO OrderCars (Car_Id, Company_Id, Data, Data2, Are, Shops, Tonnage, Mileage, Earned, Expenses, Profit, Freight, Profitability, Driver)" + "VALUES (@car_id, @company_Id, @data, @data2, @are, @shops, @tonnage, @mileage, @earned, @expenses, @profit, @freight, @profitability, @driver)";
            SQLiteCommand insertCommand = new SQLiteCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SQLiteParameter[]
                {
                  new SQLiteParameter("are", Are),
                  new SQLiteParameter("car_Id", Car_Id),
                  new SQLiteParameter("company_Id", Company_Id),
                  new SQLiteParameter("data", Data),
                  new SQLiteParameter("shops", Shops),
                  new SQLiteParameter("tonnage", Tonnage),
                  new SQLiteParameter("mileage", Mileage),
                  new SQLiteParameter("earned", Earned),
                  new SQLiteParameter("expenses", Expenses),
                   new SQLiteParameter("profit", Profit),
                   new SQLiteParameter("freight", Freight),
                   new SQLiteParameter("profitability", Profitability),
                   new SQLiteParameter("data2", Data2),
                   new SQLiteParameter("driver", Driver),
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update()
        {
            var commandString = "UPDATE OrderCars SET Car_Id=@car_Id, Are = @are, Mileage=@mileage WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("are", BD_Order.are),
                       new SQLiteParameter("Id",OrderCar_Id ),
                        new SQLiteParameter("car_Id",BD_Order.car_Id),
                        new SQLiteParameter("mileage",BD_Order.milage)
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update2()
        {
            var commandString = "UPDATE OrderCars SET Are = @are, Mileage=@mileage WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("are", BD_Order.are),
                       new SQLiteParameter("Id",OrderCar_Id ),
                       new SQLiteParameter("mileage",BD_Order.milage)
                });
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update3()
        {
            var commandString = "UPDATE OrderCars SET Car_Id=@car_Id WHERE(OrderCar_Id = @id)";
            SQLiteCommand updateCommand = new SQLiteCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SQLiteParameter[] {
                       new SQLiteParameter("Id",OrderCar_Id ),
                        new SQLiteParameter("car_Id",BD_Order.car_Id)
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
                var commandString = "DELETE FROM OrderCars WHERE(OrderCar_id = @id)";
                SQLiteCommand deleteCommand = new SQLiteCommand(commandString, connection);
                deleteCommand.Parameters.AddWithValue("id", id);
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static IEnumerable<OrderCar> Order_Search()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, O.Data2, O.Are, C.Car_Id, C.Company_Id, O.Driver, C.Brand, C.Number, C.Type, Co.Name from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id Where ( Co.Name ='" + MainWindowOrder.name + "' or O.Driver ='" + MainWindowOrder.name + "' or C.Brand ='" + MainWindowOrder.name + "' or C.Number ='" + MainWindowOrder.name + "' or O.Are ='" + MainWindowOrder.name + "' or C.Type ='" + MainWindowOrder.name + "')";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetDateTime(1);
                    var data2 = reader.GetString(2);
                    var are = reader.GetString(3);
                    var car_id = reader.GetInt32(4);
                    var company_Id = reader.GetInt32(5);
                    var driver = reader.GetString(6);
                    var brand = reader.GetString(7);
                    var number = reader.GetString(8);
                    var type = reader.GetString(9);
                    var name = reader.GetString(10);
                    var orderCar = new OrderCar
                    {
                        OrderCar_Id = orderCar_Id,
                        Data = data,
                        Data2 = data2,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Are = are,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> Order_Search2()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, O.Data2, O.Are, C.Car_Id, C.Company_Id, O.Driver, C.Brand, C.Number, C.Type, Co.Name from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id Where O.Data2 ='" + MainWindowOrder.datatime + "' AND (C.Car_Id =" + MainWindowOrder._id + " or Co.Name ='" + MainWindowOrder.name + "' or O.Driver ='" + MainWindowOrder.name + "' or C.Brand ='" + MainWindowOrder.name + "' or C.Number ='" + MainWindowOrder.name + "' or O.Are ='" + MainWindowOrder.name + "' or C.Type ='" + MainWindowOrder.name + "')";
            SQLiteCommand getAllCommand = new SQLiteCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetDateTime(1);
                    var data2 = reader.GetString(2);
                    var are = reader.GetString(3);
                    var car_id = reader.GetInt32(4);
                    var company_Id = reader.GetInt32(5);
                    var driver = reader.GetString(6);
                    var brand = reader.GetString(7);
                    var number = reader.GetString(8);
                    var type = reader.GetString(9);
                    var name = reader.GetString(10);
                    var orderCar2 = new OrderCar
                    {
                        OrderCar_Id = orderCar_Id,
                        Data = data,
                        Data2 = data2,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Are = are,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Type = type,
                    };
                    yield return orderCar2;
                }
            };
            connection.Close();
        }


        public void Clear()
        {

            this.Company_Id = 0;

        }

        public static OrderCar GetOrder(int name, string datatime)
        {
            foreach (var order in GetAllOrder3())
            {
                if (order.Car_Id == name && order.Data2 == datatime)
                    return order;


            }

            return null;
        }      
    }
}




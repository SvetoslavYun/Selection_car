using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace Selection_car
{
    public class OrderCar
    {
        public int OrderCar_Id { get; set; }
        public String Data { get; set; }
        public int Car_Id { get; set; }
        public int Company_Id { get; set; }
        public String Name { get; set; }
        public String Driver { get; set; }
        public String Brand { get; set; }
        public String Number { get; set; }
        public decimal Rate { get; set; }

        static SqlConnection connection;

        public OrderCar()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SqlConnection(connString);
        }

        static OrderCar()
        {
            // Получение строки подключения из файла конфигурации
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            // Создание объекта подключения
            connection = new SqlConnection(connString);
        }

        public override string ToString()
        {
            return String.Format($"id={OrderCar_Id};     date={Data};      id={Car_Id};     Организация.Id: {Company_Id};     Организация: {Name};          Водитель: {Driver};      Марка: {Brand};      Номер: {Number};      Тариф за км: {Rate}");
        }

        public static IEnumerable<OrderCar> GetAllOrder()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, C.Car_Id, C.Company_Id, C.Driver, C.Brand, C.Number, C.Rate, Co.Name from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data=N'"+ MainWindowOrder.datatime + "'";            
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetString(1);
                    var car_id = reader.GetInt32(2);
                    var company_Id = reader.GetInt32(3);
                    var driver = reader.GetString(4);
                    var brand = reader.GetString(5);
                    var number = reader.GetString(6);
                    var rate = reader.GetDecimal(7);
                    var name = reader.GetString(8);
                    var orderCar = new OrderCar
                    {
                        OrderCar_Id = orderCar_Id,
                        Data = data,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name=name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Rate = rate,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> GetAllOrder3()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, C.Car_Id, C.Company_Id, C.Driver, C.Brand, C.Number, C.Rate, Co.Name from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE O.Data=N'" + MainWindowOrder.datatime + "' AND (Co.Name = N'" + MainWindowOrder.CompanyName + "')";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetString(1);
                    var car_id = reader.GetInt32(2);
                    var company_Id = reader.GetInt32(3);
                    var driver = reader.GetString(4);
                    var brand = reader.GetString(5);
                    var number = reader.GetString(6);
                    var rate = reader.GetDecimal(7);
                    var name = reader.GetString(8);
                    var orderCar = new OrderCar
                    {
                        OrderCar_Id = orderCar_Id,
                        Data = data,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Rate = rate,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public void Insert()
        {
            var commandString = "INSERT INTO OrderCars (Car_Id, Data)" + "VALUES (@car_id, @data)";
            SqlCommand insertCommand = new SqlCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[]
                {
                  new SqlParameter("car_Id", Car_Id),
                       new SqlParameter("data", Data),
                                
                });

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }
             
        public static void Delete(int id)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var commandString = "DELETE FROM OrderCars WHERE(OrderCar_id = @id)";
                SqlCommand deleteCommand = new SqlCommand(commandString, connection);
                deleteCommand.Parameters.AddWithValue("id", id);
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static IEnumerable<OrderCar> Order_Search()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, C.Car_Id, C.Company_Id, C.Driver, C.Brand, C.Number, C.Rate, Co.Name from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id Where (O.OrderCar_Id=" + MainWindowOrder._id + " or Co.Name = N'" + MainWindowOrder.name + "' or C.Driver = N'" + MainWindowOrder.name + "' or C.Brand = N'" + MainWindowOrder.name + "' or C.Number = N'" + MainWindowOrder.name + "' or O.Data = N'" + MainWindowOrder.name + "')";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetString(1);
                    var car_id = reader.GetInt32(2);
                    var company_Id = reader.GetInt32(3);
                    var driver = reader.GetString(4);
                    var brand = reader.GetString(5);
                    var number = reader.GetString(6);
                    var rate = reader.GetDecimal(7);
                    var name = reader.GetString(8);
                    var orderCar = new OrderCar
                    {
                        OrderCar_Id = orderCar_Id,
                        Data = data,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Rate = rate,
                    };
                    yield return orderCar;
                }
            };
            connection.Close();
        }

        public static IEnumerable<OrderCar> Order_Search2()
        {
            var commandString = "Select O.OrderCar_Id, O.Data, C.Car_Id, C.Company_Id, C.Driver, C.Brand, C.Number, C.Rate, Co.Name from OrderCars AS O JOIN Cars AS C ON C.Car_Id = O.Car_Id JOIN Companys AS Co ON Co.Company_Id = C.Company_Id Where O.Data = N'" + MainWindowOrder.datatime + "' AND (O.OrderCar_Id=" + MainWindowOrder._id + " or Co.Name = N'" + MainWindowOrder.name + "' or C.Driver = N'" + MainWindowOrder.name + "' or C.Brand = N'" + MainWindowOrder.name + "' or C.Number = N'" + MainWindowOrder.name + "')";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
            connection.Open();
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var orderCar_Id = reader.GetInt32(0);
                    var data = reader.GetString(1);
                    var car_id = reader.GetInt32(2);
                    var company_Id = reader.GetInt32(3);
                    var driver = reader.GetString(4);
                    var brand = reader.GetString(5);
                    var number = reader.GetString(6);
                    var rate = reader.GetDecimal(7);
                    var name = reader.GetString(8);
                    var orderCar2 = new OrderCar
                    {
                        OrderCar_Id = orderCar_Id,
                        Data = data,
                        Car_Id = car_id,
                        Company_Id = company_Id,
                        Name = name,
                        Driver = driver,
                        Brand = brand,
                        Number = number,
                        Rate = rate,
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

        public static OrderCar GetOrder(int name, String datatime)
        {
            foreach (var order in GetAllOrder3())
            {
                if (order.Car_Id == name && order.Data == datatime)
                    return order;


            }

            return null;
        }
    }
}




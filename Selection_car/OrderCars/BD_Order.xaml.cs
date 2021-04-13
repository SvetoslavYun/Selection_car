using System;
using System.Configuration;
using System.Data.SQLite;
using System.Windows;

namespace Selection_car
{

    public partial class BD_Order : Window
    {
        public static String number;
        public static decimal milage;
        public static String name;
        public static String are;
        public static String are2;
        public static int car_Id;
        public BD_Order()
        {
            InitializeComponent();
            grid.DataContext = MainWindowOrder.orderCar;
            to_Driver2();
            to_Driver();
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "Select * From Areas ";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Are.Items.Add(reader.GetValue(1).ToString());
                    }
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            are = Are.Text;
            if (Number.Text == "")
            {
               
                
                    var orderCar = new OrderCar()
                    {
                        Are = are,
                    };
                cb_Selected2();
                MainWindowOrder.Radio2 = "2"; ;
                    Close();
                
            }
            if (Number.Text != "")
            {
                if (Are.Text == "")
                {
                    var orderCar = new OrderCar()
                    {
                        Car_Id = car_Id,
                    };
                    cb_Selected();
                    MainWindowOrder.Radio2 = "3"; 
                    Close();
                }
                if (Are.Text != "")
                {
                    var orderCar = new OrderCar()
                    {
                        Car_Id = car_Id,
                        Are = are,
                    };
                    cb_Selected2();
                    cb_Selected();
                    MainWindowOrder.Radio2 = "1"; ;
                    Close();
                }
            }
            if (Number.Text == "" && Are.Text == "")
            {
                MainWindowOrder.Radio2 = "999";
                Close();
            }
        }

        private void cb_Selected()
        {
            number = Number.Text;
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Cars";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(4).ToString() == number)
                        {
                            car_Id = Convert.ToInt32(reader.GetValue(0).ToString());
                        }
                       
                    }
                }
            }
        }

        private void cb_Selected2()
        {
            are2 = Are.Text;
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Areas WHERE Are ='"+ are2 + "'";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(1).ToString() == are)
                        {
                            milage = Convert.ToInt32(reader.GetValue(3).ToString());
                        }

                    }
                }
            }
        }
        public void to_Driver() /*Выводим в текст бокс список вадителей, двойной запрос*/
        {
            {
               
                try
                {
                    Number.Items.Clear();
                }
                catch
                {
                }
                var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
                string sqlExpression = "Select DISTINCT C.* from Cars AS C  JOIN Companys AS Co ON Co.Company_Id = C.Company_Id  WHERE Co.Name ='" +name+ "' And C.Car_Id not in ( Select Car_Id from OrderCars)";
                using (SQLiteConnection connection = new SQLiteConnection(connString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            Number.Items.Add(reader.GetValue(4).ToString());
                        }
                    }
                }
                string sqlExpression2 = "Select DISTINCT C.* from Cars AS C  JOIN Companys AS Co ON Co.Company_Id = C.Company_Id JOIN OrderCars AS O ON O.Car_Id = C.Car_Id  WHERE Co.Name ='" + name + "' AND C.Car_Id not in ( Select Car_Id from OrderCars WHERE Data2 ='" + MainWindowOrder.datatime + "')";
                using (SQLiteConnection connection = new SQLiteConnection(connString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(sqlExpression2, connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            Number.Items.Add(reader.GetValue(4).ToString());
                        }
                    }
                }
            }

        }
        public void to_Driver2() /*Выводим в текст бокс список вадителей, двойной запрос*/
        {
            {
                var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
                string sqlExpression = "Select * from Companys AS Co JOIN OrderCars AS O ON O.Company_Id = Co.Company_Id  WHERE O.OrderCar_Id =" + MainWindowOrder._id + " ";
                using (SQLiteConnection connection = new SQLiteConnection(connString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            name=(reader.GetValue(1).ToString());
                                               
                        }
                    }
                }
                
            }
        }
    }
}

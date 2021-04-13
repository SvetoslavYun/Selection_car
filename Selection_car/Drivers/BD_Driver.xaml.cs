using System;
using System.Configuration;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace Selection_car
{

    public partial class BD_Driver : Window
    {
        public BD_Driver()
        {
            InitializeComponent();
            grid.DataContext = MainWindowDriver.driver;
            button_Click2();

            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "SELECT * FROM Companys ORDER BY Name ASC";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();


                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Company.Items.Add(reader.GetValue(1).ToString());
                    }
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var user = Driverr.GetDriver(Driver.Text);
            if (user == null)
            { 
                if (Driver.Text == "") MessageBox.Show("Введите Ф.И.О. ");
                if (Driver.Text != "")
                {
                    if (Car.Text == "") MessageBox.Show("Выберите гос.номер. ");
                    if (Car.Text != "")
                    {
                        if (Company.Text == "") MessageBox.Show("Выберите организацию ");
                        if (Company.Text != "")
                        {
                            {
                                var driver = new Driverr()
                                {
                                    Company_Id = MainWindowDriver._companyId,
                                    Car_Id = MainWindowDriver._carId,
                                    Driver = Driver.Text,
                                    Phone = Phone.Text,
                                    Adres = Adres.Text
                                };
                                driver.Insert();
                                Close();
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Такой Водитель уже есть");
            }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Driver.Text == null) ;
                Driver.Text = "";
                Phone.Text = "";
                Adres.Text = "";
                MainWindowDriver.driver.Clear();
            }
            catch
            {
            }
        }

        private void button_Click2()
        {
            try
            {
                if (Driver.Text == null) ;
                Driver.Text = "";
                Phone.Text = "";
                Adres.Text = "";
                MainWindowDriver.driver.Clear();
            }
            catch
            {
            }
        }

        private void cb_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string tit = comboBox.SelectedItem.ToString();
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "Select * from Companys";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(1).ToString() == tit)
                        {
                            MainWindowDriver._companyId = Convert.ToInt32(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
        }
   
        private void Add_Car()
        {
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "Select * from Cars AS C JOIN Companys AS Co ON Co.Company_Id = C.Company_Id WHERE Co.Company_Id =" + MainWindowDriver._companyId + "";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();


                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        Car.Items.Add(reader.GetValue(4).ToString());
                    }
                }
            }
        }
      
        private void button_Click3(object sender, RoutedEventArgs e)
        {
            try
            {
                Car.Items.Clear();
            }
            catch
            {
            }
            var driver = new Driverr()
            {
                Company_Id = MainWindowDriver._companyId,

            };
            Add_Car();
           
        }

        private void Car_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string tit = comboBox.SelectedItem.ToString();
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "Select * from Cars ";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(4).ToString() == tit)
                        {
                            MainWindowDriver._carId = Convert.ToInt32(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
        }
    }
}

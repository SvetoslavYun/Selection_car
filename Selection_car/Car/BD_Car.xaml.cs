using System;
using System.Configuration;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Input;

namespace Selection_car
{

    public partial class BD_Form : Window
    {
        public BD_Form()
        {
            InitializeComponent();            
            Type.Items.Add("Хлебная");
            Type.Items.Add("Кондитерская");
            Type.Items.Add("Сборная");
            Type.Items.Add("Районная");
            grid.DataContext = MainWindowCar.car;
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
           
            var user = Car.GetCar(Number.Text);
            if (user == null)
            {
                if (Brand.Text == "") MessageBox.Show("Введите марку");
                else
                {
                    if (Number.Text == "") MessageBox.Show("Введите гос номер ");
                    else
                    {
                        if (Type.Text == "") Type.Text = "Хлебная";
                        else
                        {
                            if (Company.Text == "") MessageBox.Show("Выберите организацию ");
                            if (Company.Text != "")
                            {
                                var car = new Car()
                                {
                                    Company_Id = MainWindowCar._companyId,
                                    Driver = "",
                                    Brand = Brand.Text,
                                    Number = Number.Text,
                                    Type = Type.Text,
                                    Trays = 0,
                                    Containers = 0,
                                    Fired = "",
                                    PriceFuel = 0,
                                    СonFuel = 0,
                                    Depreciation = 0,
                                    Beltol = 0

                                };
                                car.Insert();
                                Close();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Такой номер уже есть");
            }
        }


    private void button_Click2()
        {
            try
            {
                if (Company.Text == null) ;
                Company.Text = "";
                Brand.Text = "";
                Number.Text = "";
                MainWindowCar.car.Clear();
            }
            catch
            {
            }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            button_Click2();
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
                            MainWindowCar._companyId = Convert.ToInt32(reader.GetValue(0).ToString());
                        }                        
                    }
                }
            }           
        }

    }
}

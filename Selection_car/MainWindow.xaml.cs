using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Configuration;

namespace Selection_car
{
    public partial class Name_Password : Window
    {
        public static String are="Минск";
        ObservableCollection<Area> Areas;
        public static Area area;
        public static String Admin;
        public static int _id=1;
        public static String RadioAdmin;
        public Name_Password()
        {
            InitializeComponent();
            button_Click2();
            button_Metod();
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
            string sqlExpression = "Select * from Users ORDER BY Name ASC";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                SQLiteDataReader reader = command.ExecuteReader();


                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        textBox.Items.Add(reader.GetValue(1).ToString());

                    }
                }
            }
        }
        
   
                             //Кнопка открытия второго окна
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindowUser.name = textBox.Text;
            MainWindowUser.password = textBox2.Password;
            var user = User.GetUser(MainWindowUser.name, MainWindowUser.password);
            if (user == null) MessageBox.Show("Неверные Имя или пароль");
            else
          {
            cb_Selected();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); //ждет закрытия окна         
            this.Close();
               
          }

        }

        private void button_Metod()
        {
            var user = User.GetUser2(_id);
            if (user == null)
            {
                MessageBox.Show(" Добавте пользователя!!!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show(); //ждет закрытия окна         
                this.Close();
                MainWindowUser mainWindowUser = new MainWindowUser();
                mainWindowUser.Show(); //ждет закрытия окна 
                RadioAdmin = "1";
            }
            if (user != null) { RadioAdmin = "2"; }
        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void comboBox_User_DropDownOpened(object sender, EventArgs e)
        {
            if (textBox.Items.Contains(textBox.Text) == false)
            {
                textBox.Items.Add(textBox.Text);
            }
        }
        private void button_Click2()
        {
            var user = Area.GetArea(are);
            if (user == null)
            {
                var area = new Area()
                {
                    Are = "Минск",
                    Cities = "Минский район",
                    Distance = 75,
                    Days = "Каждый день",
                    BelTol = 0
                };
                area.Insert2();
            }
        }

        private void cb_Selected()
        {
            var connString = ConfigurationManager.ConnectionStrings["DemoConnection"].ConnectionString;
             var commandString = "SELECT * FROM Users Where(Name ='" + MainWindowUser.name + "' And Password ='" + MainWindowUser.password + "')";
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(commandString, connection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {

                        Admin = (reader.GetValue(3).ToString());

                    }
                }
            }
        }
    }
      
    
}





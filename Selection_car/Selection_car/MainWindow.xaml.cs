using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;


namespace Selection_car
{
    public partial class Name_Password : Window
    {
       

        public Name_Password()
        {
            InitializeComponent();
        }
        
   
                             //Кнопка открытия второго окна
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindowUser.name = textBox.Text;
            MainWindowUser.password = textBox2.Text;
            var user = User.GetUser(MainWindowUser.name, MainWindowUser.password);
            if (user == null) MessageBox.Show("Неверные Имя или пароль");
            else
            {
                MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); //ждет закрытия окна         
            this.Close();
            }

        }

        private void button_Click2(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}





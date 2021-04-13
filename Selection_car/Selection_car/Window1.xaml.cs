using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;


namespace Selection_car
{
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }


        //Кнопка открытия второго окна
        private void btnFill_ClickUser(object sender, RoutedEventArgs e)
        {
            MainWindowUser mainWindowUser = new MainWindowUser();
            mainWindowUser.Show(); //ждет закрытия окна           
            this.Close();
        }

    }
}
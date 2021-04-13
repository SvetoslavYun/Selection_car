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

        private void btnFill_ClickCompani(object sender, RoutedEventArgs e)
        {
            MainWindowCompany mainWindowCompany = new MainWindowCompany();
            mainWindowCompany.Show(); //ждет закрытия окна           
            this.Close();
        }

        private void btnFill_ClickCar(object sender, RoutedEventArgs e)
        {
            MainWindowCar mainWindowCar = new MainWindowCar();
            mainWindowCar.Show(); //ждет закрытия окна           
            this.Close();
        }

        private void btnFill_ClickOrder(object sender, RoutedEventArgs e)
        {
            MainWindowOrder mainWindowOrder = new MainWindowOrder();
            mainWindowOrder.Show(); //ждет закрытия окна           
            this.Close();
        }
    }
}
using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Selection_car.Areas;

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
            if (Name_Password.Admin == "Администратор")
            {
                MainWindowUser mainWindowUser = new MainWindowUser();
                mainWindowUser.ShowDialog(); //ждет закрытия окна 
            }
            else
            {
                MessageBox.Show("Права доступа ограничены ");
            }
        }

        private void btnFill_ClickCompani(object sender, RoutedEventArgs e)
        {
            MainWindowCompany mainWindowCompany = new MainWindowCompany();
            mainWindowCompany.ShowDialog(); //ждет закрытия окна           
        }

        private void btnFill_ClickDriver(object sender, RoutedEventArgs e)
        {
            MainWindowDriver mainWindowDriver = new MainWindowDriver();
            mainWindowDriver.ShowDialog(); //ждет закрытия окна   

        }
        private void btnFill_ClickCar(object sender, RoutedEventArgs e)
        {
            MainWindowCar mainWindowCar = new MainWindowCar();
            mainWindowCar.ShowDialog(); //ждет закрытия окна           
        }

        private void btnFill_ClickOrder(object sender, RoutedEventArgs e)
        {
            MainWindowOrder mainWindowOrder = new MainWindowOrder();
            mainWindowOrder.ShowDialog(); //ждет закрытия окна           
        }

        private void btnFill_ClickArea(object sender, RoutedEventArgs e)
        {
            AreasWindow areasWindow = new AreasWindow();
            areasWindow.ShowDialog(); //ждет закрытия окна           
        }

        private void btnFill_ClickCalculator(object sender, RoutedEventArgs e)
        {
            CalculatorWindow calculatorWindow = new CalculatorWindow();
            calculatorWindow.ShowDialog(); //ждет закрытия окна  
        }
    }
}
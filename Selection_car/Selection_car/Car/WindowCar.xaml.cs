using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Controls;


namespace Selection_car
{
    public partial class MainWindowCar : Window
    {
        public static bool flag;//добавить/изменить
        ObservableCollection<Car> Cars;
        public static int _id;
        public static int _companyId;
        public static String Variable;
        public static String name;
        public static Car car;

        public MainWindowCar()
        {
            Cars = new ObservableCollection<Car>();
            InitializeComponent();
            lBox.DataContext = Cars;
        }

        public void FillData()//заполнить список
        {
            Cars.Clear();
            foreach (var item in Car.GetAllCar())
            {
                Cars.Add(item);
            }
        }

        public void FillData_Search()//заполнить список
        {
            Cars.Clear();
            foreach (var item in Car.Car_Search())
            {
                Cars.Add(item);
            }
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            FillData();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((Car)lBox.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                var id = ((Car)lBox.SelectedItem).Car_Id;
                Car.Delete(id);
                FillData();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }


        }

        private void btnAdd__Click(object sender, RoutedEventArgs e)
        {
     
            BD_Form bd_Form = new BD_Form();
            bd_Form.Owner = this;//первичное окно назначаем главным
            bd_Form.ShowDialog();//ждет закрытия окна
            FillData();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((Car)lBox.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                var id = ((Car)lBox.SelectedItem).Car_Id;

                car = (Car)lBox.SelectedItem;
                BD_Form2 bd_Form = new BD_Form2();
                bd_Form.Owner = this;//первичное окно назначаем главным
                bd_Form.ShowDialog();//ждет закрытия окна
                FillData();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void to_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "") MessageBox.Show("Введите данные");
            if (textBox.Text != "")
            {

                bool result = int.TryParse(textBox.Text, out MainWindowCar._id);
                if (result == true) ;
                else MainWindowCar.name = textBox.Text;
                FillData_Search();
                try
                {

                    MainWindowCar._id = 0;
                    MainWindowCar.name = "";
                    MainWindowCar.car.Clear();
                }
                catch
                {
                }

                try
                {
                    if (textBox.Text == null) ;
                    textBox.Text = "";
                    MainWindowCar.car.Clear();
                }
                catch
                {
                }
            }

        }

        private void to_Delet(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox.Text == null) ;
                textBox.Text = "";
                MainWindowCar.car.Clear();
            }
            catch
            {
            }
        }

        private void bth_MainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); //ждет закрытия окна         
            this.Close();
        }
    }
}





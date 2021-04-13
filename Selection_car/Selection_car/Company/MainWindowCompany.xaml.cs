using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace Selection_car
{
    public partial class MainWindowCompany : Window
    {
        public static bool flag;//добавить/изменить
        ObservableCollection<Company> Companys;
        public static int _id;
        public static String name;
        public static String password;
        public static Company company;

        public MainWindowCompany()
        {
            Companys = new ObservableCollection<Company>();
            InitializeComponent();
            lBox.DataContext = Companys;
        }

        public void FillData()//заполнить список
        {
            Companys.Clear();
            foreach (var item in Company.GetAllCompany())
            {
                Companys.Add(item);
            }
        }

        public void FillData_Search()//заполнить список
        {
            Companys.Clear();
            foreach (var item in Company.Company_Search())
            {
                Companys.Add(item);
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
                if ((Company)lBox.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                var id = ((Company)lBox.SelectedItem).Company_Id;
                Company.Delete(id);
                FillData();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }


        }

        private void btnAdd__Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            BD_Company bd_Form = new BD_Company();
            bd_Form.Owner = this;//первичное окно назначаем главным
            bd_Form.ShowDialog();//ждет закрытия окна
            FillData();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((Company)lBox.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                var id = ((Company)lBox.SelectedItem).Company_Id;
                flag = false;
                company = (Company)lBox.SelectedItem;
                BD_Company bd_Form = new BD_Company();
                bd_Form.Owner = this;//первичное окно назначаем главным
                bd_Form.ShowDialog();//ждет закрытия окна
                FillData();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }

        }

        private void toNameId_Click(object sender, RoutedEventArgs e)          /* Кнопка поиска*/
        {
            To_Name to_id = new To_Name();
            to_id.Owner = this;
            to_id.ShowDialog();//ждет закрытия окна              
            FillData_Search();         
            try
            {

                MainWindowCompany._id = 0;
                MainWindowCompany.name = "";
                MainWindowCompany.company.Clear();
            }
            catch
            {
            }
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); //ждет закрытия окна         
            this.Close();
        }
    }
}





using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace Selection_car
{
    public partial class MainWindowUser : Window
    {
        public static bool flag;//добавить/изменить
        ObservableCollection<User> Users;
        public static int _id;
        public static String name;
        public static String password;
        public static User user;

        public MainWindowUser()
        {
            Users = new ObservableCollection<User>();
            InitializeComponent();
            lBox.DataContext = Users;
        }

        public void FillData()//заполнить список
        {
            Users.Clear();
            foreach (var item in User.GetAllUser())
            {
                Users.Add(item);
            }
        }

        public void FillData_Search()//заполнить список
        {
            Users.Clear();
            foreach (var item in User.User_Search())
            {
                Users.Add(item);
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
                if ((User)lBox.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                var id = ((User)lBox.SelectedItem).User_Id;
                User.Delete(id);
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
            BD_User bd_Form = new BD_User();
            bd_Form.Owner = this;//первичное окно назначаем главным
            bd_Form.ShowDialog();//ждет закрытия окна
            FillData();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((User)lBox.SelectedItem == null) throw new Exception("Не выбрана строка, произведите выбор");
                var id = ((User)lBox.SelectedItem).User_Id;
                flag = false;
                user = (User)lBox.SelectedItem;
                BD_User bd_Form = new BD_User();
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
            To_NameId to_id = new To_NameId();
            to_id.Owner = this;
            to_id.ShowDialog();//ждет закрытия окна              
            FillData_Search();
            try
            {

                MainWindowUser._id = 0;
                MainWindowUser.name = "";
                MainWindowUser.user.Clear();
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





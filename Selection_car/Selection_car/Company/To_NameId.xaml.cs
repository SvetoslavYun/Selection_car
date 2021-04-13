
using System.Windows;

namespace Selection_car
{
    /// <summary>
    /// Логика взаимодействия для To_ID.xaml
    /// </summary>
    public partial class To_Name : Window
    {
        public To_Name()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool result = int.TryParse(textBox.Text, out MainWindowCompany._id);
            if (result == true) Close();
            else MainWindowCompany.name = textBox.Text;
            Close();
          
        }
    }
}

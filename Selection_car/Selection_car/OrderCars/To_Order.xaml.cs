
using System.Windows;

namespace Selection_car
{
    /// <summary>
    /// Логика взаимодействия для To_ID.xaml
    /// </summary>
    public partial class To_Order : Window
    {
        public To_Order()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool result = int.TryParse(textBox.Text, out MainWindowOrder._id);
            if (result == true) Close();
            else MainWindowOrder.name = textBox.Text;
            Close();
        }
    }
}

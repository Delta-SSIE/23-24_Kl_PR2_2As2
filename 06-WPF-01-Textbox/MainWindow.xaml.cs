using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _06_WPF_01_Textbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isHelloWorld;

        public MainWindow()
        {
            InitializeComponent();

            GreetingLbl.Content = "Hello World!";
            _isHelloWorld = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isHelloWorld)
                GreetingLbl.Content = "Goodbye World!";
            else
                GreetingLbl.Content = "Hello World!";

            _isHelloWorld = !_isHelloWorld;
        }
    }
}
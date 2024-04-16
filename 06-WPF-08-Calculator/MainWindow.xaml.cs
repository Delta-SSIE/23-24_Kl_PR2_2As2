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

namespace _06_WPF_08_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Operation { Add, Subtract, Multiply, Divide }

        private double _lastNumber;
        private Operation _operation;
        private string _currentText;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void RenderDisplay()
        {
            DisplayTB.Text = _currentText;
        }

        private void numberBtnClick(object sender, RoutedEventArgs e)
        {
            Button pressedBtn = (Button)sender;
            string pressedNum = pressedBtn.Content.ToString();

            if (pressedNum == "0" && _currentText == "0")
                return;

            _currentText += pressedNum;
            RenderDisplay();
        }

        private void ACBtn_Click(object sender, RoutedEventArgs e)
        {
            _currentText = "0";
            RenderDisplay();
        }

        private void percentBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
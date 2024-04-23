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
        //private string CurrentText;

        public string CurrentText
        {
            get { return (string)GetValue(CurrentTextProperty); }
            set { SetValue(CurrentTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentTextProperty =
            DependencyProperty.Register("CurrentText", typeof(string), typeof(MainWindow), new PropertyMetadata(""));



        public MainWindow()
        {
            InitializeComponent();
            CurrentText = "0";
        }

        //private void RenderDisplay()
        //{
        //    DisplayTB.Text = CurrentText;
        //}

        private void numberBtnClick(object sender, RoutedEventArgs e)
        {
            Button pressedBtn = (Button)sender;
            string pressedNum = pressedBtn.Content.ToString();

            if (CurrentText == "0")
                CurrentText = pressedNum;
            else
                CurrentText += pressedNum;
    
            //RenderDisplay();
        }

        private void ACBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentText = "0";
            //RenderDisplay();
        }

        private void percentBtn_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(CurrentText);
            CurrentText = MyMath.Percent(number).ToString();
            //RenderDisplay();
        }

        private void dotBtn_Click(object sender, RoutedEventArgs e)
        {
            string decimalDot = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (!CurrentText.Contains(decimalDot))
            {
                CurrentText += decimalDot;
            }

            //RenderDisplay();
        }

        private void plusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(CurrentText);
            CurrentText = (-number).ToString();
        }

        private void operationBtn_Click(object sender, RoutedEventArgs e)
        {
            _lastNumber = double.Parse(CurrentText); //z obrazovky posuň do paměti
            CurrentText = "0"; //na obrazovku dej nulu

            //zapamatuj si operaci, která se bude dělat
            if (sender == plusBtn)
                _operation = Operation.Add;
            else if (sender == minusBtn)
                _operation = Operation.Subtract;
            else if(sender == multiplyBtn)
                _operation = Operation.Multiply;
            else if(sender == divideBtn)
                _operation = Operation.Divide;
        }

        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            double currentNumber = double.Parse(CurrentText);

            double result = _operation switch
            {
                Operation.Add => MyMath.Add(_lastNumber, currentNumber),
                Operation.Subtract => MyMath.Subtract(_lastNumber, currentNumber),
                Operation.Multiply => MyMath.Multiply(_lastNumber, currentNumber),
                Operation.Divide => MyMath.Divide(_lastNumber, currentNumber),
                _ => 0
            };

            CurrentText = result.ToString();
        }

        private void CalcWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Add:
                    operationBtn_Click(plusBtn, null);
                    break;

                //...

                case Key.NumPad0:
                    numberBtnClick(zeroBtn, null);
                    break;

                //...

            }
        }
    }
}
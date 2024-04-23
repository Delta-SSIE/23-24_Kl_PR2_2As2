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

namespace _06_WPF_09_Pexeso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _rows;
        private int _cols;

        public MainWindow()
        {
            InitializeComponent();

            _rows = 3;
            _cols = 4;

            SetUpBoard();
        }

        private void SetUpBoard()
        {
            Board.RowDefinitions.Clear();
            Board.ColumnDefinitions.Clear();
            Board.Children.Clear();

            //připravit grid
            for (int i = 0; i < _rows; i++)
            {
                Board.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < _cols; i++)
            {
                Board.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _cols; x++)
                {
                    //Rectangle rect = new Rectangle();
                    //rect.Fill = Brushes.Aqua;
                    //rect.Stroke = Brushes.Black;
                    //rect.StrokeThickness = 3;

                    //Grid.SetColumn(rect, x);
                    //Grid.SetRow(rect, y);

                    //Board.Children.Add(rect);
                    GameCard card = new GameCard();
                    card.MouseLeftButtonDown += Card_MouseLeftButtonDown;


                    Grid.SetColumn(card, x);
                    Grid.SetRow(card, y);
                    Board.Children.Add(card);
                }
            }
        }

        private void Card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GameCard card = (GameCard)sender;
            card.Flip();
        }
    }
}
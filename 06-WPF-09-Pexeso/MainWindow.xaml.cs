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
using System.Windows.Threading;

namespace _06_WPF_09_Pexeso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Stage { Setup, NoCardFlipped, OneCardFlipped, WaitForFlipBack, Results }

        const int FlipBackDelay = 500; //milliseconds

        private int _rows;
        private int _cols;
        private Stage _stage = Stage.Setup;

        private GameCard _firstCard;
        private GameCard _secondCard;

        private DispatcherTimer _timer;


        public MainWindow()
        {
            InitializeComponent();
            UpdateVisibility();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(FlipBackDelay);
            _timer.Tick += FlipCardsBack;

        }

        private void FlipCardsBack(object? sender, EventArgs e)
        {
            NextStage();
        }

        private void NextStage()
        {
            switch (_stage)
            {
                case Stage.Setup:
                    //nastav velikost
                    //rozdej
                    SetUpBoard();

                    _stage = Stage.NoCardFlipped;
                    break;

                case Stage.NoCardFlipped:
                    _stage = Stage.OneCardFlipped;
                    break;

                case Stage.OneCardFlipped:
                    _timer.Start();
                    _stage = Stage.WaitForFlipBack;
                    break;

                case Stage.WaitForFlipBack:
                    _timer.Stop();

                    if (_firstCard.Symbol == _secondCard.Symbol)
                    {
                        //pak smaž
                        Board.Children.Remove(_firstCard);
                        Board.Children.Remove(_secondCard);
                    }
                    //nebo otoč zpět
                    else
                    {
                        _firstCard.Flip();
                        _secondCard.Flip();
                    }

                    //když zbývají karty, vrať se
                    if (Board.Children.Count > 0)
                        _stage = Stage.NoCardFlipped;

                    //jinak další fáze
                    else
                        _stage = Stage.Results;
                    break;

                case Stage.Results:
                    //začni znovu
                    _stage = Stage.Setup;
                    break;
                default:
                    break;
            }
            UpdateVisibility();
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

            //vytvořim kartičky
            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _cols; x++)
                {
                    GameCard card = new GameCard();
                    card.MouseLeftButtonDown += Card_MouseLeftButtonDown;

                    Grid.SetColumn(card, x);
                    Grid.SetRow(card, y);
                    Board.Children.Add(card);
                }
            }

            int[] symbols = RandomizedSymbols();
            for (int i = 0; i < symbols.Length; i++)
            {
                ((GameCard)Board.Children[i]).Symbol = symbols[i].ToString();
            }

        }

        private void Card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GameCard card = (GameCard)sender;
            
            //ručně nezavírám
            if (card.IsFlipped) 
                return;

            if (_stage == Stage.NoCardFlipped)
            {
                _firstCard = card;
                card.Flip();
                NextStage();
            }
            else if (_stage == Stage.OneCardFlipped)
            {
                _secondCard = card;
                card.Flip();
                NextStage();
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string btnText = button.Content.ToString();

            if (btnText == "2x2")
            {
                _rows = 2;
                _cols = 2;
            }
            else if (btnText == "3x4")
            {
                _rows = 3;
                _cols = 4;
            }
            else if (btnText == "4x4")
            {
                _rows = 4;
                _cols = 4;
            }
            NextStage();
        }

        private void UpdateVisibility()
        {
            SetupPanel.Visibility = _stage == Stage.Setup ? Visibility.Visible : Visibility.Hidden;
            GamePanel.Visibility = (
                _stage == Stage.NoCardFlipped 
                || _stage == Stage.OneCardFlipped
                || _stage == Stage.WaitForFlipBack
            ) ? Visibility.Visible : Visibility.Hidden;
            ResultsPanel.Visibility = _stage == Stage.Results ? Visibility.Visible : Visibility.Hidden;
        }

        private int[] RandomizedSymbols()
        {
            //vytvoř dvojice čísel
            int count = _rows * _cols;
            int[] symbols = new int[count];
            for (int i = 0; i < count / 2; i++)
            {
                symbols[i] = i + 1;
                symbols[count / 2 + i] = i + 1;
            }

            Random rnd = new Random();
            //zamíchej
            symbols = symbols.OrderBy(x => rnd.NextDouble()).ToArray();

            return symbols;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RestartBtn_Click(object sender, RoutedEventArgs e)
        {
            NextStage();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for GameCard.xaml
    /// </summary>
    public partial class GameCard : UserControl
    {
        public GameCard()
        {
            InitializeComponent();
        }

        public void Flip()
        {
            if (CardBack.Visibility == Visibility.Visible)
                CardBack.Visibility = Visibility.Hidden;
            else
                CardBack.Visibility = Visibility.Visible;
        }
    }
}

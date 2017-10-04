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

namespace TheBandit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[,] cards = new string[,] { { "/Images/Nio.png", "/Images/Ess.png", "/Images/Knekt.png" }, { "/Images/Dam.png", "/Images/Ess.png", "/Images/Dam.png" }, { "/Images/Knekt.png", "/Images/Ess.png", "/Images/Kung.png" } };
        GameBoard gameBoard = new GameBoard();
        Wallet wallet = new Wallet();
        
        public MainWindow()
        {
            InitializeComponent();
            GenerateBoard();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            wallet.AddMoney(Int32.Parse(Amount.Text));
            DisplayMoney.Text = wallet.Money().ToString();
            Amount.Text = "";
        }

        private void Spin_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.Parse(Bet.Text) <= wallet.Money())
            {
                cards = gameBoard.Spin();
                wallet.SubtractMoney(Int32.Parse(Bet.Text));
                GenerateBoard();
                wallet.AddMoney(gameBoard.CheckWinnings(cards, Int32.Parse(Bet.Text)));
                MessageBox.Show("Sum: " + gameBoard.GetSum() + " Lines: " + gameBoard.GetWinningLines());
                DisplayMoney.Text = wallet.Money().ToString();
            }
            else
            {
                MessageBox.Show("Insert more money!");
            }
            
        }

        private void GenerateBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Image tile = new Image { Source = new BitmapImage(new Uri(cards[i, j], UriKind.Relative)) };
                    Grid.SetColumn(tile, i);
                    Grid.SetRow(tile, j);
                    SlotGrid.Children.Add(tile);
                }
            }
        }        
    }
}

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
        int[,] cards = new int[,] { { 1, 6, 3 }, { 4, 6, 4 }, { 3, 6, 5 } };
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
                    Image tile = new Image { Source = new BitmapImage(new Uri(GetUri(cards[i, j]), UriKind.Relative)) };
                    Grid.SetColumn(tile, i);
                    Grid.SetRow(tile, j);
                    SlotGrid.Children.Add(tile);
                }
            }
        }

        private string GetUri(int i)
        {
            switch (i)
            {
                case 1:
                    return "/Images/Nio.png";
                case 2:
                    return "/Images/Tio.png";
                case 3:
                    return "/Images/Knekt.png";
                case 4:
                    return "/Images/Dam.png";
                case 5:
                    return "/Images/Kung.png";
                case 6:
                    return "/Images/Ess.png";
                default:
                    return "";
            }
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

//Andreas Norberg, 2017
namespace TheBandit
{    
    public partial class GameWindow : Window
    {
        string[,] cards = new string[,] { { "/Images/Nio.png", "/Images/Ess.png", "/Images/Knekt.png" }, { "/Images/Dam.png", "/Images/Ess.png", "/Images/Dam.png" }, { "/Images/Knekt.png", "/Images/Ess.png", "/Images/Kung.png" } };
        GameBoard gameBoard = new GameBoard();
        Wallet wallet = new Wallet();
        Person person = new Person("default", 1);

        public GameWindow(string name, int age)
        {
            SetPerson(name, age);
            InitializeComponent();
            GenerateBoard();
            WelcomeBlock.Text = "Welcome to The Bandit, " + person.Name() + "!";
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wallet.AddMoney(Int32.Parse(Amount.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please use a numerical value. \n" + ex);
            }
            DisplayMoney.Text = wallet.Money().ToString();
            Amount.Text = "";
        }

        private void Spin_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.Parse(Bet.Text) <= wallet.Money())
            {
                cards = gameBoard.Spin();
                wallet.SubtractMoney(Int32.Parse(Bet.Text));
                DisplayMoney.Text = wallet.Money().ToString();
                GenerateBoard();
                wallet.AddMoney(gameBoard.CheckWinnings(cards, Int32.Parse(Bet.Text)));

                if (gameBoard.GetSum() > 0)
                {
                    MessageBox.Show("You won " + gameBoard.GetSum() + " Bandit dollars from " + gameBoard.GetWinningLines() + " winning lines!");
                }
                
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

        private void SetPerson(string name, int age)
        {
            person = new Person(name, age);
        }
    }
}

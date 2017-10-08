using System;
using System.Windows;

//Andreas Norberg, 2017
namespace TheBandit
{
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                ControlAge(Int32.Parse(AgeBox.Text));
                GameWindow gameWindow = new GameWindow(NameBox.Text, Int32.Parse(AgeBox.Text));
                gameWindow.Show();
                this.Close();
            }
            catch (IllegalAgeException ex)
            {
                MessageBox.Show("IllegalAgeException: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please use a numerical value: " + ex.Message);
            }
        }

        private void ControlAge(int age)
        {
            if (age < 0) throw new IllegalAgeException("You need to have been born!");
            if (age < 21 && age > 0) throw new IllegalAgeException("You need to be at least 21 to play The Bandit!");
        }
    }
}

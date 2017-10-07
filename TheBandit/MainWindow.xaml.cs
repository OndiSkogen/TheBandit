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
                MessageBox.Show("Please use a numerical value. \n" + ex.Message);
            }
        }

        private void ControlAge(int age)
        {
            if (age < 0) throw new IllegalAgeException("You need to be born!");
            if (age < 21 && age > 0) throw new IllegalAgeException("You need to be at least 21 to play The Bandit!");
        }
    }
}

using System.Text;
using System.Data;
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

namespace WPF
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

        private int rnd;
        private int count;

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                count = 0;
                Random random = new Random();
                int begin = int.Parse(BeginRange.Text);
                int end = int.Parse(EndRange.Text);
                var guess = random.Next(begin, end);
                rnd = guess;
            }

            catch (FormatException)
            {
                MessageBox.Show("The Format is wrong, Please enter the valid integer.");
            }

            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }

            Text.Content = "Please guess a number and press Guess:";
        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            count++;

            try
            {
                int myguess = int.Parse(myGuess.Text);

                if(myguess < 0)
                {
                   throw new NegativeNumberException();
                }
                    
                else if (myguess > rnd)
                {
                    Text.Content = $"My number is less than {myguess}";
                }

                else if (myguess < rnd)
                {
                    Text.Content = $"My number is greater than {myguess}";
                }

                else
                {
                    Text.Content = $"Well Done! It took you {count} attempts.";
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("The Format is wrong, Please enter the valid integer.");
            }

            catch (NegativeNumberException)
            {
                MessageBox.Show("The Format is wrong, Please enter the valid integer.");
            }

            catch(Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }

            myGuess.Clear();
        }
    }
}

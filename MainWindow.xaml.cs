using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace WinApi_22._09._23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         private int randomNumber;
        private int attempts;
        private bool gameOver;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            Random random = new Random();
            randomNumber = random.Next(0, 101);
            attempts = 0;
            gameOver = false;

            guessTextBox.Text = "";
            resultLabel.Content = "Спроби: 0";
        }

        private void CheckGuess(int guess)
        {
            attempts++;

            if (guess == randomNumber)
            {
                MessageBox(new IntPtr(0), $"Вітаємо! Ви вгадали число {randomNumber} за {attempts} спроб.", "Вгадано!", 0x40); 
                gameOver = true;
            }
            else if (guess < randomNumber)
            {
                messageLabel.Content = "Загадане число більше.";
            }
            else
            {
                messageLabel.Content = "Загадане число менше.";
            }

            resultLabel.Content = $"Спроби: {attempts}";
        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            if (!gameOver)
            {
                if (int.TryParse(guessTextBox.Text, out int guess))
                {
                    if (guess >= 0 && guess <= 100)
                    {
                        CheckGuess(guess);
                    }
                    else
                    {
                        MessageBox(new IntPtr(0), "Будь ласка, введіть число від 0 до 100.", "Помилка", 0x10); 
                    }
                }
                else
                {
                    MessageBox(new IntPtr(0), "Будь ласка, введіть коректне число.", "Помилка", 0x10);
                }
            }
            else
            {
                MessageBox(new IntPtr(0), "Гра закінчена. Для початку нової гри натисніть 'Нова гра'.", "Гра закінчена", 0x40);
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }
    }
}

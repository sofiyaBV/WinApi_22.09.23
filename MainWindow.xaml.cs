using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace WinApi_22._09._23
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
      
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,   string lpWindowName);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
        private IntPtr notepadHandle;
        private Timer timer;
        private void Timer_Tick(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString("HH:mm:ss"); 
            SendMessage(notepadHandle, 0x000C, IntPtr.Zero, currentTime);
        }
        private void Click_click(object sender, RoutedEventArgs e)
        {
            notepadHandle = FindWindow("Notepad", null);
            if (notepadHandle == IntPtr.Zero)
            {
                MessageBox.Show("Вікно Блокнота не знайдено.");
                Close();
            }

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); 
            timer.Tick += Timer_Tick;
            timer.Start();
        }
    }
}

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
        public MainWindow()
        {
            InitializeComponent();
        }
      
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,   string lpWindowName);
      
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private void Click_click(object sender, RoutedEventArgs e)
        {
            IntPtr notepadHandle = FindWindow(null, "Calculator");
            if (notepadHandle  != IntPtr.Zero) {
                SendMessage(notepadHandle, 0x0010, IntPtr.Zero, IntPtr.Zero);
               MessageBox.Show("Вікно калькулятор закрито.");
            }
            else
            {
               MessageBox.Show("Вікно калькулятор не знайдено.");
            }
        }
    }
}

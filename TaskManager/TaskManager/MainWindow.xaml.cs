using System.Diagnostics;
using System.Windows;


namespace SPR_411_TaskManager
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = Process.GetProcesses();

            //selected.Kill();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Process selected = (Process)grid.SelectedItem;
            //string res = "";//add infirmation about process
            //MessageBox.Show(selected.ProcessName, "Task Manager", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);

            MessageBox.Show(processName.Text);
        }
    }
}
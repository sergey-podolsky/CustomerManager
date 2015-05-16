using System.Data;
using System.Windows;

namespace DataArt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static readonly MainWindowsViewModel ViewModel = new MainWindowsViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.DbContext.SaveChanges();
                ViewModel.IsChanged = false;
            }
            catch (UpdateException exception)
            {
                MessageBox.Show(exception.InnerException.Message, "Update Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

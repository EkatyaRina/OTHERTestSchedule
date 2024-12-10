using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestSchedule.ViewModel;

namespace TestSchedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly MainWindowViewModel _mainWindowViewModel;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();  // Устанавливаем DataContext

            //DataContext = _mainWindowViewModel = new MainWindowViewModel();
        }
    }
}
using CustomerAnalyticSystem.BLL.Models;
using System.Windows;
using System.Text.RegularExpressions;

namespace CustomerAnalyticSystem.UI
{
    /// <summary>
    /// Interaction logic for EditOrderWindow.xaml
    /// </summary>
    public partial class EditOrderWindow : Window
    {
        MainWindow _mainWindow;
        public EditOrderWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void ButtonDeleteOrderEditOrderWndw_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show(this, $"Вы уверены, что хотите удалить заказ № {((OrderBaseModel)_mainWindow.ListViewClients.SelectedItem).Id}?",
                   "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //удаление
            }
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+");

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void TextBoxAmountOfProductEditOrderWndw_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            IsTextAllowed(TextBoxAmountOfProductEditOrderWndw.Text);
        }

        private void TextBoxPriceOfUnitEditOrderWndw_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            IsTextAllowed(TextBoxPriceOfUnitEditOrderWndw.Text);
        }

        private void ButtonEditOrderStatus_Click(object sender, RoutedEventArgs e)
        {
            EditStatusWindow editStatusWindow = new EditStatusWindow(_mainWindow);
            editStatusWindow.Show();
        }
    }
}

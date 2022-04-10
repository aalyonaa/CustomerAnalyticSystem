using System.Windows;
using System.Text.RegularExpressions;
using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using System;


namespace CustomerAnalyticSystem.UI
{

    public partial class AddOrderWindow : Window
    {
        private MainWindow _mainWindow;
        public AddOrderWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void ButtonEditOrderStatus_Click(object sender, RoutedEventArgs e)
        {
            EditStatusWindow editStatusWindow = new EditStatusWindow(_mainWindow);
            editStatusWindow.Show();
        }
        //private void FillingEditOrderWindowComboBoxGroups()
        //{
        //    var service = new OrderCheckStatusService();
        //    var statusList = service.GetAllStatus();
        //    foreach (var g in statusList)
        //    ////foreach (string Key in _mainWindow.GroupsIdAndGroups.Keys)
        //    //{
        //    //    ComboBoxProductGroupAddWndw.Items.Add(g.Name);
        //    //}
        //}


        private static readonly Regex _regex = new Regex("[^0-9.-]+");

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void TextBoxAmountOfProductAddOrderWndw_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            IsTextAllowed(TextBoxAmountOfProductAddOrderWndw.Text);
        }

        private void TextBoxPriceOfUnitAddOrderWndw_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            IsTextAllowed(TextBoxAmountOfProductAddOrderWndw.Text);
        }
    }
}

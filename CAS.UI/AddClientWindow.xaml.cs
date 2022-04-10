using CustomerAnalyticSystem.BLL;
using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Text.RegularExpressions;

namespace CustomerAnalyticSystem.UI
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private MainWindow _mainWindow;
        private List<CustomerTypeModel> _customerTypes = new List<CustomerTypeModel>();
        private List<ContactTypeModel> _contactTypes = new List<ContactTypeModel>();
        public AddClientWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _mainWindow.IsEnabled = false;

            _customerTypes = GetCustomerTypeModels();
            _contactTypes = GetContactTypes();

            FillComboBoxContactType(_contactTypes);
            FillCustomerTypeComboBox(_customerTypes);
        }

        private List<ContactTypeModel> GetContactTypes()
        {
            ContactService serve = new ContactService();
            return serve.GetAllContactTypeModel();
        }

        private void FillComboBoxContactType(List<ContactTypeModel> list)
        {
            ComboBoxContactType.Items.Clear();

            foreach (ContactTypeModel model in list)
            {
                ComboBoxContactType.Items.Add(model);
            }
        }

        private List<CustomerTypeModel> GetCustomerTypeModels()

        {

            CustomerService serve = new CustomerService();
            return serve.GetAllCustomerTypeModel();

        }

        private void FillCustomerTypeComboBox(List<CustomerTypeModel> list)
        {
            foreach (CustomerTypeModel model in list)
            {
                ComboBoxAddTypeOfClient.Items.Add(model);
            }
        }

        // не доделано!!!
        private void ButtonAddClient_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxAddClientSurname.Text != ""
                && TextBoxAddClientName.Text != ""
                && ComboBoxAddTypeOfClient.SelectedIndex != -1)
            {
                CustomerModel customerModel = new CustomerModel()
                {
                    FirstName = TextBoxAddClientName.Text,
                    LastName = TextBoxAddClientSurname.Text,
                    TypeId = _customerTypes[ComboBoxAddTypeOfClient.SelectedIndex].Id
                };


                CustomerService serve = new CustomerService();
                serve.AddCustomer(customerModel);

                _mainWindow.customersList = _mainWindow.GetDictCustomerInfoModelWithId();
                _mainWindow.FillingCustomerStackPanel(_mainWindow.customersList);

                int index = _mainWindow.ListViewClients.Items.Count - 1;
                _mainWindow.ListViewClients.SelectedIndex = index;
                int CustomerId = _mainWindow.customersList[index].Id;

                foreach (CommentModel comment in ListViewComments.Items)
                {
                    serve.AddCommentByCustomerId(CustomerId, comment);
                }

                foreach (ContactBaseModel contact in ListViewContact.Items)
                {
                    contact.CustomerId = CustomerId;

                    ContactService contServe = new ContactService();
                    contServe.AddContact(contact);
                }

                this.Close();
            }
        }

        private void ButtonAddContactAddClientWndw_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxContactType.SelectedIndex > -1 && TextBoxContact.Text != "")
            {
                ContactBaseModel model = new ContactBaseModel()
                {
                    ContactTypeId = (_contactTypes)[ComboBoxContactType.SelectedIndex].Id,
                    Value = TextBoxContact.Text
                };

                ListViewContact.Items.Add(model);
            }
        }

        private void ButtonDeleteContactAddClientWndw_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewContact.SelectedIndex != -1)
            {
                ListViewContact.Items.Remove(ListViewContact.SelectedItem);
            }
        }

        private void ButtonDeleteCommentAddClientWndw_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewComments.SelectedIndex != -1)
            {
                ListViewComments.Items.Remove(ListViewComments.SelectedItem);
            }
        }

        private void ButtonAddCommentAddClientWndw_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxComment.Text != "")
            {
                CommentModel model = new CommentModel()
                {
                    Text = TextBoxComment.Text
                };

                ListViewComments.Items.Add(model);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _mainWindow.IsEnabled = true;
            _mainWindow.customersList = _mainWindow.GetDictCustomerInfoModelWithId();
            _mainWindow.FillingCustomerStackPanel(_mainWindow.customersList);
        }

        private void TextBoxContact_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (ComboBoxContactType.Text == "Phone")
            {
                e.Handled = !IsTextAllowed(e.Text);
                IsTextAllowed(TextBoxContact.Text);
            }
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+");

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}

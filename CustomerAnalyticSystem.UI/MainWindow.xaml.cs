using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
using CustomerAnalyticSystem.BLL;

namespace CustomerAnalyticSystem.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> TagsIdAndTags = new Dictionary<string, int>();
        public MainWindow()
        {
            InitializeComponent();
            FillingDictTags();
            FillingComboBoxTags();
            FillingListViewProducts();
            CustomerService custServe = new CustomerService();
            List<CustomerModel> customers = custServe.GetAllCustomerModels();

            //foreach (CustomerModel customer in customers)
            //{
            //    Button btn = new Button();
            //    btn.Name = Convert.ToString("qwe" + customer.Id);
            //    btn.Content = $"{customer.LastName} {customer.FirstName}";
            //    StackPanelAllCustomers.Children.Add(btn);
            //}
        }


        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            //OrderInfoByOrderIdModel keks = new();
            //OrderInfoByOrderIdService test = new();
            //keks = test.GetOrderInfoByOrderId(Convert.ToInt32( TextBoxOrderId.Text));
            //TextBoxInformationAboutOrder.Text = keks.OrderId + "Order" + keks.CustomerId + "Customer id" + "\n";
            //foreach(var c in keks.Items)
            //{
            //    TextBoxInformationAboutOrder.Text += $"({c.ProductId} prodId \t {c.Mark} \t {c.Mark} = Mark \n";
            //}
            var temp = new OrderCheckStatusService();
            var listOrder = temp.GetBaseOrderModel();
            foreach(var c in listOrder)
            {
                Button newOrder = new();
                newOrder.Name = $"q_{c.Id}";
                newOrder.Click += ButtonOrder_Click;
                newOrder.Content = $"{c.Date}, {c.CustomerId}";
                StackPanelAllOrders.Children.Add(newOrder);
            }
        }

        private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FillingDictTags()
        {
            var service = new ProductTagGroupService();
            var tagList = service.GetAllTags();
            foreach (var t in tagList)
            {
                TagsIdAndTags.Add(t.Name, t.Id);
            }
        }

        private void FillingComboBoxTags()
        {
            var tags = new ProductTagGroupService();
            var listTags = tags.GetAllTags();
            foreach(var t in listTags)
            {
                ComboBoxTags.Items.Add(t);
            }
        }

        private void FillingListViewProducts()
        {
            ListViewProducts.Items.Clear();

            if (ComboBoxTags.SelectedIndex != -1)
            {
                string tag = ComboBoxTags.SelectedItem.ToString();
                int id;
                TagsIdAndTags.TryGetValue(tag, out id);
                var products = new ProductTagGroupService();
                var listProducts = products.GetAllProductsByTagId(id);
                foreach (var p in listProducts)
                {
                    ListViewProducts.Items.Add(p);
                }
            }
            else
            {
                var products = new ProductTagGroupService();
                var listProducts = products.GetAllProducts();
                foreach (var p in listProducts)
                {
                    ListViewProducts.Items.Add(p);
                }
            }
        }

        private void ComboBoxTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillingListViewProducts();
        }
    }
}


using CustomerAnalyticSystem.BLL;
using CustomerAnalyticSystem.BLL.Analytics.ProductInfoModel;
using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CustomerAnalyticSystem.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string, int> TagsIdAndTags = new Dictionary<string, int>();
        public Dictionary<string, int> GroupsIdAndGroups = new Dictionary<string, int>();
        public Dictionary<string, int> StatusIdAndStatus = new Dictionary<string, int>();

        public List<CustomerInfoModel> customersList = new List<CustomerInfoModel>();
        public GeneralStatistics stat = new();
        public Dictionary<int, OrderBaseModel> ordersDict = new Dictionary<int, OrderBaseModel>();

        public AllInfo info { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            info = AllInfo.GetInstance();
            info.GeneralInfo = new();
            info.CustomersInfo = new(info.GeneralInfo);
            info.ProductInfo = new(info.CustomersInfo);

            FillingDictTags();
            FillingDictGroups();
            FillingDictStatus();
            customersList = GetDictCustomerInfoModelWithId();

            FillingComboBoxStatus();
            FillingComboBoxTags();
            FillingComboBoxGroups();
            FillingComboBoxAnalitic();

            FillingListViewProducts();
            FillingListViewOrders();
            FillingCustomerStackPanel(customersList);

        }

        private void ComboBoxTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTags.SelectedIndex != -1)
            {
                ComboBoxGroups.SelectedIndex = -1;
            }
            FillingListViewProducts();
        }

        private void ComboBoxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxGroups.SelectedIndex != -1)
            {
                ComboBoxTags.SelectedIndex = -1;
            }
            FillingListViewProducts();
        }

        private void ButtonViewAllProducts_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxTags.SelectedIndex != -1 || ComboBoxGroups.SelectedIndex != -1)
            {
                ComboBoxGroups.SelectedIndex = -1;
                ComboBoxTags.SelectedIndex = -1;
            }
            FillingListViewProducts();
        }

        private void ButtonFastProductDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewProducts.SelectedIndex > -1)
            {
                if (System.Windows.MessageBox.Show(this, $"Вы уверены, что хотите удалить {((ProductBaseModel)ListViewProducts.SelectedItem).Name}?",
                   "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ProductBaseModel actual = (ProductBaseModel)ListViewProducts.SelectedItem;
                    int id = actual.Id;
                    var products = new ProductService();
                    products.DeleteProductById(id);
                    FillingListViewProducts();
                }
            }
            else
            {
                MessageBox.Show("Выберите продукт");
            }
        }

        private void ButtonFastClientDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewClients.SelectedIndex > -1)
            {
                if (System.Windows.MessageBox.Show(this, $"Вы уверены, что хотите удалить клиента " +
                    $"{((CustomerInfoModel)ListViewClients.SelectedItem).FirstName} {((CustomerInfoModel)ListViewClients.SelectedItem).LastName}?",
                   "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    CustomerService serve = new CustomerService();
                    serve.DeleteCustomerById(((CustomerInfoModel)ListViewClients.SelectedItem).Id);
                    customersList = GetDictCustomerInfoModelWithId();
                    FillingCustomerStackPanel(customersList);
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя");
            }
        }

        private void ButtonFastOrderDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewOrders.SelectedIndex > -1)
            {
                if (System.Windows.MessageBox.Show(this, $"Вы уверены, что хотите удалить {((OrderBaseModel)ListViewOrders.SelectedItem).Id}?",
                   "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    OrderBaseModel actual = (OrderBaseModel)ListViewOrders.SelectedItem;
                    int id = actual.Id;
                    var orders = new OrderCheckStatusService();
                    orders.DeleteOrderById(id);
                    FillingListViewOrders();
                }
            }
            else
            {
                MessageBox.Show("Выберите продукт");
            }
        }

        private void ComboBoxStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewOrders.SelectedIndex = -1;
            FillingListViewOrders();
        }

        private void ButtonViewAllOrders_Click(object sender, RoutedEventArgs e)
        {
            ListViewCheck.Items.Clear();
            ComboBoxStatus.SelectedIndex = -1;
            FillingListViewOrders();
        }

        private void ComboBoxAnalitic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillingListViewLogic();
        }

        private void ListViewOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewOrders.SelectedIndex > -1)
            {
                FillingListViewCheck();
            }

        }

        private void ListViewClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillingListViewInterestedClients();
        }

        #region filling

        public void FillingListViewInterestedClients()
        {
            //ListViewInterestedClients.Items.Clear();
            //var a = info.ProductInfo.Products[((ProductBaseModel)(ListViewProducts.SelectedItem)).Id];
            //foreach (var c in a.Customers)
            //{
            //    ListViewInterestedClients.Items.Add(c);

            //}
           // foreach(var c in a.ProductsRecommends) 
        }

        public void FillingCustomerStackPanel(List<CustomerInfoModel> list)
        {
            ListViewClients.Items.Clear();
            foreach (CustomerInfoModel model in list)
            {
                ListViewClients.Items.Add(model);
            }
        }

        public void FillingComboBoxStatus()
        {
            ComboBoxStatus.Items.Clear();
            foreach (string Key in StatusIdAndStatus.Keys)
            {
                ComboBoxStatus.Items.Add(Key);
            }
        }

        public void FillingComboBoxTags()
        {
            ComboBoxTags.Items.Clear(); ;
            foreach (string Key in TagsIdAndTags.Keys)
            {
                ComboBoxTags.Items.Add(Key);
            }
        }

        public void FillingComboBoxGroups()
        {
            ComboBoxGroups.Items.Clear();
            foreach (string Key in GroupsIdAndGroups.Keys)
            {
                ComboBoxGroups.Items.Add(Key);
            }
        }

        public void FillingListViewProducts()
        {
            ListViewProducts.Items.Clear();

            if (ComboBoxTags.SelectedIndex > -1)
            {
                int id = TagsIdAndTags[ComboBoxTags.SelectedItem.ToString()];
                var products = new ProductService();
                var listProducts = products.GetAllProductsByTagId(id);
                foreach (var p in listProducts)
                {
                    ListViewProducts.Items.Add(p);
                }
            }
            else if (ComboBoxGroups.SelectedIndex > -1)
            {
                int id = GroupsIdAndGroups[ComboBoxGroups.SelectedItem.ToString()];
                var products = new ProductService();
                var listProducts = products.GetAllProductsByGroupId(id);
                foreach (var p in listProducts)
                {
                    ListViewProducts.Items.Add(p);
                }
            }
            else
            {
                var products = new ProductService();
                var listProducts = products.GetAllProducts();
                foreach (var p in listProducts)
                {
                    ListViewProducts.Items.Add(p);
                }
            }
        }

        public void FillingListViewOrders()
        {
            ListViewOrders.Items.Clear();
            if (ComboBoxStatus.SelectedIndex > -1)
            {
                var orders = new OrderCheckStatusService();
                int id = StatusIdAndStatus[ComboBoxStatus.SelectedItem.ToString()];
                var listOrders = orders.GetAllOrdersByStatusId(id);
                foreach (var p in listOrders)
                {
                    ListViewOrders.Items.Add(p);
                }
            }
            else
            {
                var orders = new OrderCheckStatusService();
                var listOrders = orders.GetBaseOrderModel();
                foreach (var p in listOrders)
                {
                    ListViewOrders.Items.Add(p);
                }
            }
        }

        public void FillingComboBoxAnalitic()
        {
            ComboBoxAnalitic.Items.Add("Товары");
            ComboBoxAnalitic.Items.Add("Группы");
            ComboBoxAnalitic.Items.Add("Тэги");
        }

        public void FillingListViewLogic()
        {
            ListViewLogic.Items.Clear();

            if (ComboBoxAnalitic.SelectedIndex == 0)
            {
                foreach (var val in stat.Products.Values)
                {
                    ListViewLogic.Items.Add(val);
                }
            }
            else if (ComboBoxAnalitic.SelectedIndex == 1)
            {
                foreach (var val in stat.Groups.Values)
                {
                    ListViewLogic.Items.Add(val);
                }
            }
            else if (ComboBoxAnalitic.SelectedIndex == 2)
            {
                foreach (var val in stat.Tags.Values)
                {
                    ListViewLogic.Items.Add(val);
                }
            }

        }

        public void FillingListViewCheck()
        {
            ListViewCheck.Items.Clear();
            var service = new OrderCheckStatusService();
            int orderId = ((OrderBaseModel)(ListViewOrders.SelectedItem)).Id;
            var check = service.GetCheckByOrderId(orderId);
            foreach (var c in check)
            {
                ListViewCheck.Items.Add(c);
            }
        }
        public void FillingOrderStackPanel(Dictionary<int, OrderBaseModel> dict)
        {
            ListViewOrders.Items.Clear();

            foreach (KeyValuePair<int, OrderBaseModel> pair in dict)
            {
                ListViewOrders.Items.Add(pair.Value);
            }
        }
        #endregion

        #region dictionary
        public List<CustomerInfoModel> GetDictCustomerInfoModelWithId()
        {
            CustomerService customerService = new CustomerService();
            return customerService.GetAllCustomerInfoModels();
        }

        public void FillingDictGroups()
        {
            GroupsIdAndGroups.Clear();
            var service = new ProductService();
            var groupList = service.GetAllGroups();
            foreach (var g in groupList)
            {
                GroupsIdAndGroups.Add(g.Name, g.Id);
            }
        }

        public void FillingDictTags()
        {
            TagsIdAndTags.Clear();
            var service = new ProductService();
            var tagList = service.GetAllTags();
            foreach (var t in tagList)
            {
                TagsIdAndTags.Add(t.Name, t.Id);
            }
        }

        public void FillingDictStatus()
        {
            StatusIdAndStatus.Clear();
            var service = new OrderCheckStatusService();
            var statusList = service.GetAllStatus();
            foreach (var s in statusList)
            {
                StatusIdAndStatus.Add(s.Name, s.Id);
            }
        }
        public Dictionary<int, OrderBaseModel> GetDictGetOrderById()
        {
            var orderService = new OrderCheckStatusService();
            List<OrderBaseModel> orders = orderService.GetBaseOrderModel();

            Dictionary<int, OrderBaseModel> ordersDict = new Dictionary<int, OrderBaseModel>();

            foreach (OrderBaseModel order in orders)
            {
                ordersDict.Add(order.Id, order);
            }
            return ordersDict;
        }

        #endregion

        #region Open pop-up wndws

        private void ButtonOpenAddOrderWndw_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow(this);
            addOrderWindow.Show();

        }
        
        private void ButtonOpenEditOrderWndw_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewOrders.SelectedIndex > -1)
            {
                EditOrderWindow editOrderWindow = new EditOrderWindow(this);
                editOrderWindow.Show();
            }
            else
            {
                MessageBox.Show("Выберите заказ");
            }
        }

        private void ButtonOpenWindowOfProductAdding_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow(this);
            addProductWindow.Show();
        }

        private void ButtonOpenWindowOfAddingClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow(this);
            addClientWindow.Show();
        }

        private void ButtonOpenWindowOfProductEditing_Click(object sender, RoutedEventArgs e)
        {

            if (ListViewProducts.SelectedIndex > -1)
            {
                ProductBaseModel product = (ProductBaseModel)ListViewProducts.SelectedItem;
                EditProductWindow editProductWindow = new EditProductWindow(this, product);
                editProductWindow.Show();
            }
            else
            {
                MessageBox.Show("Выберите продукт для редактирования");

            }
        }

        private void ButtonEditTags_Click(object sender, RoutedEventArgs e)
        {
            EditTagsWindow editTagsWindow = new EditTagsWindow(this);
            editTagsWindow.Show();
        }

        private void ButtonEditGroups_Click(object sender, RoutedEventArgs e)
        {
            EditGroupsWindow editGroupsWindow = new EditGroupsWindow(this);
            editGroupsWindow.Show();
        }

        private void ButtonOpenWindowOfEditingClient_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewClients.SelectedIndex > -1)
            {
                EditClientWindow editClientWindow = new EditClientWindow(this, (CustomerInfoModel)ListViewClients.SelectedItem);
                editClientWindow.Show();
            }
        }




        #endregion
        
    }
}


using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using System;
using System.Windows;

namespace CustomerAnalyticSystem.UI
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private MainWindow _mainWindow;
        public AddProductWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            FillingComboBoxTagsForAddProduct();
            FillingEditProductWindowComboBoxGroups();
            _mainWindow = mainWindow;
        }

        private void FillingEditProductWindowComboBoxGroups()
        {
            var service = new ProductService();
            var groupList = service.GetAllGroups();
            foreach (var g in groupList)
            
            {
                ComboBoxProductGroupAddWndw.Items.Add(g.Name);
            }
        }

        private void FillingComboBoxTagsForAddProduct()
        {
            var service = new ProductService();
            var tagList = service.GetAllTags();
            foreach (var t in tagList)
            
            {
                ComboBoxTagsForAddProduct.Items.Add(t.Name);
            }
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxProductNameAddWndw.Text != String.Empty && ComboBoxProductGroupAddWndw.SelectedIndex != -1)
            {
                foreach (var p in _mainWindow.stat.Products.Values)
                {
                    if (p.Name == TextBoxProductNameAddWndw.Text)
                    {
                        MessageBox.Show("Продукт с таким наименованием уже существует");
                        return;
                    }
                }

                ProductBaseModel product = new ProductBaseModel()
                {
                    Name = TextBoxProductNameAddWndw.Text,
                    Description = TextBoxProductDescriptionAddWndw.Text,
                    GroupName = ComboBoxProductGroupAddWndw.SelectedItem.ToString()
                };

                int id = _mainWindow.GroupsIdAndGroups[ComboBoxProductGroupAddWndw.SelectedItem.ToString()];

                ProductService service = new ProductService();
                service.AddProduct(product.Name, product.Description, id);
                _mainWindow.FillingListViewProducts();

                foreach (var item in ListViewTagsAddWndw.Items)
                {
                    string tag = item.ToString();
                    int id1 = _mainWindow.TagsIdAndTags[tag];
                    ProductService service1 = new ProductService();
                    int count = _mainWindow.ListViewProducts.Items.Count - 1;
                    _mainWindow.ListViewProducts.SelectedIndex = count;
                    ProductBaseModel newProduct = (ProductBaseModel)_mainWindow.ListViewProducts.SelectedItem;
                    service.AddProductTag(newProduct.Id, id1);
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Введите информацию о продукте");
            }
        }

        private void ButtonAddTag_Click(object sender, RoutedEventArgs e)
        {
            ListViewTagsAddWndw.Items.Add(ComboBoxTagsForAddProduct.SelectedItem.ToString());
            ListViewTagsAddWndw.UpdateLayout();


        }

        private void ButtonDeleteTag_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewTagsAddWndw.SelectedIndex > -1)
            {
                ListViewTagsAddWndw.Items.Remove(ListViewTagsAddWndw.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите тэг для удаления");
            }
        }

        private void ButtonEditTags_Click(object sender, RoutedEventArgs e)
        {
            EditTagsWindow editTagsWindow = new EditTagsWindow(_mainWindow);
            editTagsWindow.Show();
        }

        private void ButtonEditGoup_Click(object sender, RoutedEventArgs e)
        {
            EditGroupsWindow editGroupsWindow = new EditGroupsWindow(_mainWindow);
            editGroupsWindow.Show();
        }
    }
}

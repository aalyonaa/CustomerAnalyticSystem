using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using System;
using System.Windows;

namespace CustomerAnalyticSystem.UI
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private MainWindow _mainWindow;
        private ProductBaseModel _product = null;
        public EditProductWindow(MainWindow mainWindow, ProductBaseModel product)
        {
            InitializeComponent();
            _product = product;
            _mainWindow = mainWindow;
            FillingEditProductWindowComboBoxGroups();
            FillingComboBoxTagsForEdditProduct();
            FillingListViewTagsEditWndw();
            TextBoxProductNameEditWndw.Text = product.Name;
            TextBoxProductDescriptionEditWndw.Text = product.Description;
        }

        private void FillingEditProductWindowComboBoxGroups()
        {
            int id = -1;
            foreach (string Key in _mainWindow.GroupsIdAndGroups.Keys)
            {
                id++;
                ComboBoxProductGroupEditWndw.Items.Add(Key);
                if (Key == _product.GroupName)
                {
                    ComboBoxProductGroupEditWndw.SelectedIndex = id;
                }
            }
        }

        private void ButtonSaveChangesOfProductEditing_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxProductNameEditWndw.Text != String.Empty && ComboBoxProductGroupEditWndw.SelectedIndex != -1)
            {
                _product.Name = TextBoxProductNameEditWndw.Text;
                _product.Description = TextBoxProductDescriptionEditWndw.Text;
                _product.GroupName = ComboBoxProductGroupEditWndw.SelectedItem.ToString();
                int id = _mainWindow.GroupsIdAndGroups[ComboBoxProductGroupEditWndw.SelectedItem.ToString()];
                ProductService product = new ProductService();
                product.UpdateProductById(_product.Id, _product.Name, _product.Description, id);
                _mainWindow.FillingListViewProducts();
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите информацию о продукте");
            }
        }

        private void FillingListViewTagsEditWndw()
        {
            ListViewTagsEditWndw.Items.Clear();
            var tags = new ProductService();
            var listTags = tags.GetAllTagsByProductId(_product.Id);
            foreach (var t in listTags)
            {
                ListViewTagsEditWndw.Items.Add(t.Name);
            }
        }

        private void ButtonEditAddTag_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxEditWindowTags.SelectedIndex != -1)
            {
                var tags = new ProductService();
                string tag = ComboBoxEditWindowTags.SelectedItem.ToString();
                int id = _mainWindow.TagsIdAndTags[tag];
                tags.AddProductTag(_product.Id, id);
                FillingListViewTagsEditWndw();
            }
            else
            {
                MessageBox.Show("Не выбран тэг для добавления");
            }
        }

        private void FillingComboBoxTagsForEdditProduct()
        {
            foreach (string Key in _mainWindow.TagsIdAndTags.Keys)
            {
                ComboBoxEditWindowTags.Items.Add(Key);
            }
        }

        private void ButtonEditDeleteTag_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewTagsEditWndw.SelectedItem != null)
            {
                string tag = ListViewTagsEditWndw.SelectedItem.ToString();
                int id = _mainWindow.TagsIdAndTags[tag];
                var tag2 = new ProductService();
                tag2.DeleteProduct_TagByTagIdAndProductId(_product.Id, id);
                FillingListViewTagsEditWndw();
            }
            else
            {
                MessageBox.Show("Не выбран тэг для удаления");
            }
        }

        private void ButtonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show(this, $"Вы уверены, что хотите удалить {_product.Name}?",
               "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var products = new ProductService();
                products.DeleteProductById(_product.Id);
                _mainWindow.FillingListViewProducts();
                this.Close();
            }
        }

        private void ButtonEditTags_Click(object sender, RoutedEventArgs e)
        {
            EditTagsWindow editTagsWindow = new EditTagsWindow(_mainWindow);
            editTagsWindow.Show();
        }

        private void ButtonEditGroups_Click(object sender, RoutedEventArgs e)
        {
            EditGroupsWindow editGroupsWindow = new EditGroupsWindow(_mainWindow);
            editGroupsWindow.Show();
        }
    }
}

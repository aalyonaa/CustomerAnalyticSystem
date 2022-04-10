using CustomerAnalyticSystem.BLL.Models;
using CustomerAnalyticSystem.BLL.Services;
using System;
using System.Windows;

namespace CustomerAnalyticSystem.UI
{
    public partial class EditGroupsWindow : Window
    {
        private MainWindow _mainWindow;

        public EditGroupsWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            FillingListViewEditGroupsWndw();
        }

        private void FillingListViewEditGroupsWndw()
        {
            ListViewEditGroupsWndw.Items.Clear();
            var group = new ProductService();
            var groupList = group.GetAllGroups();
            foreach (var g in groupList)
            {
                ListViewEditGroupsWndw.Items.Add(g);
            }
        }

        private void ButtonAddGroup_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindow.GroupsIdAndGroups.ContainsKey(TextBoxNewGroup.Text) == false)
            {
                if (TextBoxNewGroup.Text != String.Empty)
                {
                    var group = new ProductService();
                    group.AddGroup(TextBoxNewGroup.Text, TextBoxDescription.Text);
                    _mainWindow.FillingComboBoxGroups();
                    FillingListViewEditGroupsWndw();
                    int count = ListViewEditGroupsWndw.Items.Count;
                    ListViewEditGroupsWndw.SelectedIndex = count - 1;
                    GroupBaseModel newGroup = ((GroupBaseModel)ListViewEditGroupsWndw.SelectedItem);
                    _mainWindow.GroupsIdAndGroups.Add(TextBoxNewGroup.Text, newGroup.Id);
                    TextBoxNewGroup.Text = "";
                    TextBoxDescription.Text = "";
                }
                else
                {
                    MessageBox.Show("Введите наименование группы");
                }
            }
            else
            {
                MessageBox.Show("Такая группа уже существует");
            }
        }

        private void ButtonDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewEditGroupsWndw.SelectedItem != null)
            {
                if (System.Windows.MessageBox.Show(this, $"Вы уверены, что хотите удалить группу " +
                    $"{((GroupBaseModel)(ListViewEditGroupsWndw.SelectedItem)).Name}? Товары данной группы также будут удалены",
                   "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = _mainWindow.GroupsIdAndGroups[((GroupBaseModel)(ListViewEditGroupsWndw.SelectedItem)).Name];
                    var group = new ProductService();
                    group.DeleteGroupById(id);
                    _mainWindow.GroupsIdAndGroups.Remove(ListViewEditGroupsWndw.SelectedItem.ToString());
                    _mainWindow.FillingComboBoxGroups();
                    FillingListViewEditGroupsWndw();
                }
            }
            else
            {
                MessageBox.Show("Выберите группу для удаления");
            }
        }

        private void ButtonEditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewEditGroupsWndw.SelectedItem != null)
            {
                if (_mainWindow.GroupsIdAndGroups.ContainsKey(TextBoxNewGroup.Text) == false)
                {
                    if (TextBoxEditGroup.Text != String.Empty)
                    {
                        GroupBaseModel model = (GroupBaseModel)ListViewEditGroupsWndw.SelectedItem;
                        int id = _mainWindow.GroupsIdAndGroups[model.Name];
                        var group = new ProductService();
                        group.UpdateGroupById(id, TextBoxEditGroup.Text, TextBoxDescription.Text);
                        _mainWindow.GroupsIdAndGroups.Remove(model.Name);
                        _mainWindow.GroupsIdAndGroups.Add(TextBoxEditGroup.Text, id);
                        _mainWindow.FillingComboBoxGroups();
                        FillingListViewEditGroupsWndw();
                        TextBoxEditGroup.Text = "";
                        TextBoxDescription.Text = "";
                        _mainWindow.FillingListViewProducts();
                    }
                    else
                    {
                        MessageBox.Show("Введите наименование группы для редактирования");
                    }

                }
                else
                {
                    MessageBox.Show("Такая группа уже существует");
                }
            }
            else
            {
                MessageBox.Show("Выберите группу для редактирования");
            }
        }

        private void TextBoxEditGroup_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ListViewEditGroupsWndw.SelectedItem != null)
            {
                var group = (GroupBaseModel)ListViewEditGroupsWndw.SelectedItem;
                TextBoxEditGroup.Text = group.Name;
                TextBoxDescription.Text = group.Description;
            }
            else
            {
                MessageBox.Show("Выберите группу для редактирования");
            }
        }
    }
}

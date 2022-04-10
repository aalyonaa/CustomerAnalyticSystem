using CustomerAnalyticSystem.BLL.Services;
using System;
using System.Windows;

namespace CustomerAnalyticSystem.UI
{
    /// <summary>
    /// Логика взаимодействия для EditStatusWindow.xaml
    /// </summary>
    public partial class EditStatusWindow : Window
    {
        MainWindow _mainWindow;
        public EditStatusWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            FillingListViewStatus();
        }

        public void FillingListViewStatus()
        {
            foreach (string Key in _mainWindow.StatusIdAndStatus.Keys)
            {
                ListViewStatus.Items.Add(Key);
            }
        }

        private void ButtonAddStatus_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewStatus.Text != String.Empty)
            {
                if (_mainWindow.StatusIdAndStatus.ContainsKey(TextBoxNewStatus.Text) == false)
                {
                    var servise = new OrderCheckStatusService();
                    servise.AddStatus(TextBoxNewStatus.Text);
                    _mainWindow.FillingDictStatus();
                    FillingListViewStatus();
                    _mainWindow.FillingComboBoxStatus();
                }
                else
                {
                    MessageBox.Show("Такой статус уже существует");
                }
            }
            else
            {
                MessageBox.Show("Введите новый статус");
            }
        }

        private void ButtonDeleteStatus_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewStatus.SelectedIndex > -1)
            {
                if (System.Windows.MessageBox.Show(this, $"Вы уверены, что хотите удалить статус {ListViewStatus.SelectedItem.ToString()}?" +
               $" Все заказы, которым присвоен этот статус будут удалены, сначала измените статус заказов",
                  "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var servise = new OrderCheckStatusService();
                    int id = _mainWindow.StatusIdAndStatus[ListViewStatus.SelectedItem.ToString()];
                    _mainWindow.StatusIdAndStatus.Remove(ListViewStatus.SelectedItem.ToString());
                    servise.DeleteStatusById(id);
                    _mainWindow.FillingComboBoxStatus();
                    FillingListViewStatus();

                }
            }
            else
            {
                MessageBox.Show("Выберите статус для удаления");
            }
        }

        private void ButtonEditStatus_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewStatus.SelectedIndex > -1)
            {
                if (TextBoxNewStatus.Text != String.Empty)
                {
                    if (_mainWindow.StatusIdAndStatus.ContainsKey(TextBoxNewStatus.Text) == false)
                    {
                        int id = _mainWindow.StatusIdAndStatus[ListViewStatus.SelectedItem.ToString()];
                        _mainWindow.StatusIdAndStatus.Remove(ListViewStatus.SelectedItem.ToString());
                        _mainWindow.StatusIdAndStatus.Add(TextBoxNewStatus.Text, id);
                        _mainWindow.FillingComboBoxStatus();
                        var servise = new OrderCheckStatusService();
                        servise.UpdateStatusById(id, TextBoxNewStatus.Text);
                        FillingListViewStatus();
                        TextBoxNewStatus.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Такой статус уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("Введите статус");
                }
            }
            else
            {
                MessageBox.Show("Выберите статус для редактирвоания");
            }
        }

       
    }
}

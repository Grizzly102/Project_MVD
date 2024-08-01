using kartoteka.Model;
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
using System.Windows.Shapes;

namespace kartoteka
{
    /// <summary>
    /// Логика взаимодействия для EmployerInfo.xaml
    /// </summary>
    public partial class EmployerInfo : Window
    {
        public void refresh()
        {
            List<Employer> newitems = App.Context.Employers.ToList();
            EmpInfoList.ItemsSource = null;
            EmpInfoList.ItemsSource = newitems;
            EmpInfoList.Items.Refresh();

        }
        public void Search()
        {
            EmpInfoList.ItemsSource = null;
            var list = App.Context.Employers.ToList();
            if (TitleBox.SelectedValue != null)
            {
                switch (TitleBox.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        list = list.Where(x => x.TitleNumberNavigation.TitleName == Convert.ToString(TitleBox.SelectedValue)).ToList();
                        break;
                }
            }
            if (DepBox.SelectedValue != null)
            {
                switch (DepBox.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        list = list.Where(x => x.DepartmentNumberNavigation.DepartmentName == Convert.ToString(DepBox.SelectedValue)).ToList();
                        break;
                }
            }
            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                list = list.Where(x => x.EmployeeName.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
            }
            EmpInfoList.ItemsSource = list;
        }
        public EmployerInfo()
        {
            InitializeComponent();
            var tit = App.Context.Titles.Select(x => x.TitleName).ToList();
            var dep = App.Context.Departments.Select(x => x.DepartmentName).ToList();
            foreach (var item in tit)
            {
                TitleBox.Items.Add(item);
            }
            foreach (var item in dep)
            {
                DepBox.Items.Add(item);
                DepAddBox.Items.Add(item);
            }
            var items = App.Context.Employers.ToList();
            EmpInfoList.ItemsSource = items;
            DepBox.SelectedIndex = 0;
            TitleBox.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IsSearch.IsChecked = true;
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsSearch.IsChecked == true)
            {
                Search();
            }

        }

        private void TitleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsSearch.IsChecked == true)
            {
                Search();
            }
        }

        private void DepBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsSearch.IsChecked == true)
            {
                Search();
            }
        }

        private void IsSearch_Checked(object sender, RoutedEventArgs e)
        {
            IsAdd.IsChecked = false;
            AddEmp.Visibility = Visibility.Hidden;
            LogLb.Content = "Должность:";
            AddEmp.Visibility = Visibility.Hidden;
            LogBox.Visibility = Visibility.Hidden;
            PassPanel.Visibility = Visibility.Hidden;
            DepAddBox.Visibility = Visibility.Hidden;
            DepBox.Visibility = Visibility.Visible;
            TitleBox.Visibility = Visibility.Visible;
        }

        private void IsAdd_Checked(object sender, RoutedEventArgs e)
        {
            AddEmp.Visibility = Visibility.Visible;
            LogBox.Visibility = Visibility.Visible;
            LogLb.Content = "Логин:";
            PassPanel.Visibility = Visibility.Visible;
            DepAddBox.Visibility = Visibility.Visible;
            DepBox.Visibility = Visibility.Hidden;
            TitleBox.Visibility = Visibility.Hidden;
            IsSearch.IsChecked = false;
        }

        private void AddEmp_Click(object sender, RoutedEventArgs e)
        {
            int pr = 0;
            var list = App.Context.Employers.ToList();
            var cs = App.Context.Employers.ToList();
            try
            {


                Employer emp = new Employer
                {
                    TokenNumber = cs.Count + 1,
                    EmployeeName = SearchBox.Text,
                    DepartmentNumber = DepBox.SelectedIndex + 1,
                    TitleNumber = 2,
                    Login = LogBox.Text,
                    Password = PassBox.Text,
                    PolicePhoto = null,
                };
                foreach (var item in list)
                {
                    if (item.Login == LogBox.Text)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует");
                        pr = 1;
                    }
                }
                if (pr != 1)
                {
                    App.Context.Employers.Add(emp);
                    App.Context.SaveChanges();
                    MessageBox.Show("Сотрудник внесен");
                    refresh();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Заполните данные");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (EmpInfoList.SelectedValue != null)
            {
                var items = (dynamic)EmpInfoList.SelectedItem;
                string Name = items.EmployeeName;
                if (MessageBox.Show("Вы точно хотите удалить ", "Удаление сотрудника", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var itemsDelete = App.Context.Employers.FirstOrDefault(x => x.EmployeeName == Name);
                    App.Context.Employers.Remove(itemsDelete);
                    App.Context.SaveChanges();
                    MessageBox.Show("Сотрудник удалён");
                    var it = App.Context.Employers.ToList();
                    foreach (var itemss in it)
                    {
                        App.Context.Entry(itemss).Reload();
                    }
                    refresh();
                }
            }
        }
    }
}

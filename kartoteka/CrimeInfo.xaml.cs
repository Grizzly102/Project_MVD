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
    /// Логика взаимодействия для CrimeInfo.xaml
    /// </summary>
    public partial class CrimeInfo : Window
    {
        public void refresh()
        {
            List<Criminal> newitems = App.Context.Criminals.ToList();
            List.ItemsSource = null;
            List.ItemsSource = newitems;
            List.Items.Refresh();
            EyeBox.Items.Clear();
            HairBox.Items.Clear();
            var eye = App.Context.Criminals.Select(x => x.EyeColor).ToList().Distinct();
            var hair = App.Context.Criminals.Select(x => x.HairColor).ToList().Distinct();
            foreach (var item in eye)
            {
                EyeBox.Items.Add(item);
            }
            foreach (var item in hair)
            {
                HairBox.Items.Add(item);
            }
        }
        public void Search()
        {
            List.ItemsSource = null;
            var list = App.Context.Criminals.ToList();
            if (EyeBox.SelectedValue != null)
            {
                switch (EyeBox.SelectedIndex)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        list = list.Where(x => x.EyeColor == Convert.ToString(EyeBox.SelectedValue)).ToList();
                        break;
                }
            }
            if (HairBox.SelectedValue != null)
            {
                switch (HairBox.SelectedIndex)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        list = list.Where(x => x.HairColor == Convert.ToString(HairBox.SelectedValue)).ToList();
                        break;
                }
            }
            if (!string.IsNullOrEmpty(NameSearch.Text))
            {
                list = list.Where(x => x.CriminalName.ToLower().Contains(NameSearch.Text.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(BornSearch.Text))
            {
                list = list.Where(x => x.BirthPlace.ToLower().Contains(NameSearch.Text.ToLower())).ToList();
            }

            if (admdatepicker.SelectedDate != null & issuedatepicker.SelectedDate != null)
            {
                list = list.Where(x => x.BirthDate >= admdatepicker.SelectedDate && x.BirthDate <= issuedatepicker.SelectedDate).ToList();
            }

            List.ItemsSource = list;


        }


        public CrimeInfo()
        {
            InitializeComponent();
            var info = App.Context.Criminals.ToList();
            List.ItemsSource = info;
            var eye = App.Context.Criminals.Select(x => x.EyeColor).ToList().Distinct();
            var hair = App.Context.Criminals.Select(x => x.HairColor).ToList().Distinct();
            foreach (var item in eye)
            {
                EyeBox.Items.Add(item);
            }
            foreach (var item in hair)
            {
                HairBox.Items.Add(item);
            }

        }

        private void BackBt_Click(object sender, RoutedEventArgs e)
        {
            DealList dl = new DealList();
            dl.Show();
            this.Close();
        }

        private void EyeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void HairBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }


        private void NameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void BornSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void DateSearch_Click(object sender, RoutedEventArgs e)
        {
            if (admdatepicker.SelectedDate != null && issuedatepicker.SelectedDate != null)
            {
                var admdate = (DateTime)admdatepicker.SelectedDate;
                var issuedate = (DateTime)issuedatepicker.SelectedDate;
                if (admdate > issuedate)
                {
                    MessageBox.Show("Ошибка", "ошибка");
                    admdatepicker.SelectedDate = null;
                    issuedatepicker.SelectedDate = null;
                    return;
                }
                Search();
            }
            else
            {
                MessageBox.Show("Выберите две даты", "Ошибка");
            }
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            HairBox.SelectedItem = null;
            EyeBox.SelectedItem = null;
            admdatepicker.SelectedDate = null;
            issuedatepicker.SelectedDate = null;
            NameSearch.Text = "";
            BornSearch.Text = "";
            var info = App.Context.Criminals.ToList();
            List.ItemsSource = info;
        }

        private void AddCrime_Click(object sender, RoutedEventArgs e)
        {
            AddCrime crime = new AddCrime();
            crime.Owner = this;
            crime.ShowDialog();
        }
    }
}

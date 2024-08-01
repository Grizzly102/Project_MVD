using iTextSharp.text.pdf;
using iTextSharp.text;
using kartoteka.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для DealList.xaml
    /// </summary>
    public partial class DealList : Window
    {
        public List<Case> items = App.Context.Cases.ToList();
        public void cnt()
        {
            CountLable.Content = $"Дел найдено:{List.Items.Count.ToString()}";

        }
        public void refresh()
        {
            List<Case> newitems = App.Context.Cases.ToList();
            List.ItemsSource = null;
            List.ItemsSource = newitems;
            List.Items.Refresh();

        }
        public void search()
        {
            var query = App.Context.Cases.ToList();
            List<Case> result = new List<Case>();
            List.ItemsSource = null;
            List.Items.Refresh();
            foreach (var item in query)
            {
                App.Context.Entry(item).Reload();
            }

            if ((bool)MyCheck.IsChecked && WeightBox.SelectedIndex > 0 && admdatepicker.SelectedDate != null && issuedatepicker.SelectedDate != null)
            {
                var admdate = (DateTime)admdatepicker.SelectedDate;
                var issuedate = (DateTime)issuedatepicker.SelectedDate;
                string sql = $"select * from Case where Case_Opening_Date between \"{admdate.ToString("yyyy-MM-dd")}\" and \"{issuedate.ToString("yyyy-MM-dd")}\"";
                foreach (var it in query)
                {
                    if (it.CaseConduct == StaticForAll.IdM && it.CrimeWeight == WeightBox.SelectedItem.ToString() && it.CaseOpeningDate > admdate && it.CaseOpeningDate < issuedate)
                    {
                        result.Add(it);
                    }
                }
            }
            else if ((bool)MyCheck.IsChecked && WeightBox.SelectedIndex > 0)
            {
                foreach (var it in query)
                {
                    if (it.CaseConduct == StaticForAll.IdM && it.CrimeWeight == WeightBox.SelectedItem.ToString())
                    {
                        result.Add(it);
                    }
                }
            }
            else if ((bool)MyCheck.IsChecked)
            {
                foreach (var it in query)
                {
                    if (it.CaseConduct == StaticForAll.IdM)
                    {
                        result.Add(it);
                    }
                }
            }
            else if (WeightBox.SelectedIndex > 0 && admdatepicker.SelectedDate != null && issuedatepicker.SelectedDate != null)
            {
                var admdate = (DateTime)admdatepicker.SelectedDate;
                var issuedate = (DateTime)issuedatepicker.SelectedDate;
                string sql = $"select * from Case where Case_Opening_Date between \"{admdate.ToString("yyyy-MM-dd")}\" and \"{issuedate.ToString("yyyy-MM-dd")}\"";
                foreach (var it in query)
                {
                    if (it.CrimeWeight == WeightBox.SelectedItem.ToString() && it.CaseOpeningDate > admdate && it.CaseOpeningDate < issuedate)
                    {
                        result.Add(it);
                    }
                }
            }
            else if (admdatepicker.SelectedDate != null && issuedatepicker.SelectedDate != null)
            {
                var admdate = (DateTime)admdatepicker.SelectedDate;
                var issuedate = (DateTime)issuedatepicker.SelectedDate;
                string sql = $"select * from Case where Case_Opening_Date between \"{admdate.ToString("yyyy-MM-dd")}\" and \"{issuedate.ToString("yyyy-MM-dd")}\"";
                foreach (var it in query)
                {
                    if (it.CaseOpeningDate > admdate && it.CaseOpeningDate < issuedate)
                    {
                        result.Add(it);
                    }
                }
            }
            else if (WeightBox.SelectedIndex > 0)
            {
                foreach (var it in query)
                {
                    if (it.CrimeWeight == WeightBox.SelectedItem.ToString())
                    {
                        result.Add(it);
                    }
                }
            }
            else
            {
                result = App.Context.Cases.ToList();
            }
            List.ItemsSource = result;
            cnt();
        }
        public DealList()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            List.ItemsSource = items;
            //var info = App.Context.Employers.ToList();
            //foreach (var item in info)
            //{
            //    if (item.TokenNumber == StaticForAll.IdM)
            //    {
            //        if (item.PolicePhoto != null)
            //        {
            //            BitmapImage bit = new BitmapImage(new Uri($"/Resources/{item.PolicePhoto}", UriKind.Relative));
            //            Avatar.Stretch = Stretch.Fill;
            //            Avatar.Source = bit;
            //        }

            //        PName.Text = item.EmployeeName;
            //    }

            //}
            cnt();
            string last = "";
            var zap = App.Context.Cases.Select(x => x.CrimeWeight).ToList().Distinct();
            foreach (var item in zap)
            {
                WeightBox.Items.Add(item);
            }

            WeightBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пасхалка");
        }

        private void infoBTN_Click(object sender, RoutedEventArgs e)
        {
            var items = (dynamic)List.SelectedItem;
            if (items.CaseConduct != StaticForAll.IdM)
            {
                MessageBox.Show("Вы не можете подробнее просматривать чужие дела");
            }
            else
            {

                StaticForAll.IdC = items.CaseId;
                DealInfo di = new DealInfo();
                di.Show();
                this.Close();
            }

        }



        private void MyCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            search();
        }

        private void MyCheck_Checked(object sender, RoutedEventArgs e)
        {
            search();
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
                DateSearch.Visibility = Visibility.Hidden;
                DateDel.Visibility = Visibility.Visible;

                search();
            }
            else
            {
                MessageBox.Show("Выберите две даты", "Ошибка");
            }
        }

        private void WeightBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            search();
        }

        private void DateDel_Click(object sender, RoutedEventArgs e)
        {
            admdatepicker.SelectedDate = null;
            issuedatepicker.SelectedDate = null;
            search();
        }



        private void AddCase_Click(object sender, RoutedEventArgs e)
        {
            AddCase ad = new AddCase();
            ad.Owner = this;
            ad.ShowDialog();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            if (List.SelectedValue != null)
            {
                var items = (dynamic)List.SelectedItem;
                int Cond = items.CaseId;
                if (items.CaseConduct != StaticForAll.IdM)
                {
                    MessageBox.Show("Вы не можете удалять чужие дела");
                }
                else
                {
                    if (MessageBox.Show("Вы точно хотите удалить ", "Удаление дела", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var cases = App.Context.CriminaleInCases.ToList();
                        foreach (var item in cases)
                        {
                            var CiC = App.Context.CriminaleInCases.FirstOrDefault(x => x.CaseId == Cond);
                            if (CiC != null)
                            {
                                App.Context.CriminaleInCases.Remove(CiC);
                                App.Context.SaveChanges();
                            }

                        }
                        var itemsDelete = App.Context.Cases.FirstOrDefault(x => x.CaseId == Cond);
                        App.Context.Cases.Remove(itemsDelete);
                        App.Context.SaveChanges();
                        MessageBox.Show("Дело удалено");
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

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            BaseFont baseFont = BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));
            doc.Open();
            for (int i = 0; i < List.Items.Count; i++)
            {
                PdfPTable table = new PdfPTable(2);
                string ttf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                PdfPCell cell = new PdfPCell();
                cell.HorizontalAlignment = 1;
                cell.Colspan = 2;
                cell.Border = 0;
                table.AddCell(cell);
                var item = (dynamic)List.Items[i];
                cell = new PdfPCell(new Phrase(new Phrase("Дело:", font)));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase(item.CaseId.ToString(), font)));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell = new PdfPCell(new Phrase(new Phrase("Открытие дела:", font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase(item.CaseOpeningDate.ToString("yyyy-MM-dd"), font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase("Место преступления:", font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase(item.CrimeScence.ToString(), font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase("Cтатья:", font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase(item.CrimeArticle.ToString(), font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase("Тяжесть преступления:", font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase(item.CrimeWeight.ToString(), font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase("Дело ведет:", font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase(item.NameP.ToString(), font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font));
                cell.HorizontalAlignment = 1;
                cell.Colspan = 2;
                cell.Border = 0;
                table.AddCell(cell);
                doc.Add(table);
            }

            doc.Close();
            Process.Start(new ProcessStartInfo("pdfTables.pdf") { UseShellExecute = true });

        }

        private void BackBt_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow men = new MenuWindow();
            men.Show();
            this.Close();
        }
    }
}

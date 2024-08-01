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
    /// Логика взаимодействия для DealInfo.xaml
    /// </summary>
    public partial class DealInfo : Window
    {
        public DealInfo()
        {
            InitializeComponent();
            int count = 0;
            int tryy = StaticForAll.IdC;
            var list = App.Context.CriminaleInCases.ToList();
            foreach (var lt in list)
            {
                if (lt.CaseId == tryy)
                {

                    DealInfoList.Items.Add(lt);
                    if (count <= 5)
                    {
                        CaseNum.Text = CaseNum.Text + lt.Case.CaseId;
                        CaseDateOp.Text = CaseDateOp.Text + Convert.ToDateTime(lt.Case.CaseOpeningDate).ToString("dd.MM.yyyy");
                        CaseDate.Text = CaseDate.Text + Convert.ToDateTime(lt.Case.CrimeDate).ToString("dd.MM.yyyy");
                        Art.Text = $"{Art.Text}{lt.Case.CrimeArticle}УК.РФ";
                        Conduct.Text = Conduct.Text + lt.Case.CaseConductNavigation.EmployeeName;
                        CaseSc.Text = CaseSc.Text + lt.Case.CrimeScence;
                        count = 6;
                    }


                }
            }

        }

        private void BackBt_Click(object sender, RoutedEventArgs e)
        {
            DealList dl = new DealList();
            dl.Show();
            this.Close();
        }
    }
}

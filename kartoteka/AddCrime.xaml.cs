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
    /// Логика взаимодействия для AddCrime.xaml
    /// </summary>
    public partial class AddCrime : Window
    {
        CrimeInfo ParentOkno { get; set; }
        public AddCrime()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string psn = PassSr.Text + PassNb.Text;
                long PassNumSr = long.Parse(psn);
                Criminal crime = new Criminal
                {
                    PassportNuberSerias = PassNumSr,
                    CriminalName = FName.Text,
                    EyeColor = EColor.Text,
                    HairColor = HColor.Text,
                    SpecialSigns = SpecSigns.Text,
                    BirthPlace = BirthPlace.Text,
                    BirthDate = (DateTime)BirthDate.SelectedDate,
                    LastResidencePlace = LastPlace.Text,
                    Height = int.Parse(HeightText.Text),
                    Photo = null,
                };
                App.Context.Criminals.Add(crime);
                App.Context.SaveChanges();
                MessageBox.Show("Преступник добавлен добавлено");
                this.Close();
                (this.Owner as CrimeInfo).refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните данные");
            }

        }
    }
}

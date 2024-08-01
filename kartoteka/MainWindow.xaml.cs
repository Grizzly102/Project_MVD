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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kartoteka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool point = false;
        public bool logpoint = false;
        public bool passpoint = false;
        private void enterButtonClick(object sender, RoutedEventArgs e)
        {

            List<Employer> sups = App.Context.Employers.ToList();
            foreach (Employer sup in sups)
            {
                if (Login_TextBox.Text == sup.Login && Password_PasswordBox.Password == sup.Password)
                {
                    if (sup.TitleNumber == 1)
                    {
                        EmployerInfo window = new EmployerInfo();
                        window.Show();
                        this.Close();
                        point = true;
                    }
                    else
                    {
                        MessageBox.Show("Успешный вход");
                        StaticForAll.IdM = sup.TokenNumber;
                        DealList window = new DealList();
                        window.Show();
                        this.Close();
                        point = true;

                    }


                }
                else if (Login_TextBox.Text != sup.Login && Password_PasswordBox.Password == sup.Password)
                {
                    logpoint = true;
                }
                else if (Login_TextBox.Text == sup.Login && Password_PasswordBox.Password != sup.Password)
                {
                    passpoint = true;
                }

            }
            if (point == false)
            {
                if (String.IsNullOrEmpty(Login_TextBox.Text) && !String.IsNullOrEmpty(Password_PasswordBox.Password))
                {
                    MessageBox.Show("Поле логин должно быть заполнено!", "Ошибка");
                }
                else if (String.IsNullOrEmpty(Password_PasswordBox.Password) && !String.IsNullOrEmpty(Login_TextBox.Text))
                {
                    MessageBox.Show("Поле пароль должно быть заполнено!", "Ошибка");
                }
                else if (String.IsNullOrEmpty(Password_PasswordBox.Password) && String.IsNullOrEmpty(Login_TextBox.Text))
                {
                    MessageBox.Show("Все поля должны быть заполнены!", "Ошибка");
                }
                else if (logpoint == true)
                {
                    MessageBox.Show("Пользователя с таким логином не существует!", "Ошибка");
                    logpoint = false;
                }
                else if (passpoint == true)
                {
                    MessageBox.Show("Пароль неверный", "Ошибка");
                    passpoint = true;
                }
                else
                {
                    MessageBox.Show("Неверные данные", "Ошибка");
                }
            }
        }
    }
}

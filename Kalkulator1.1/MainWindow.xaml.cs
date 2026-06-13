using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCalculator
{
    public partial class MainWindow : Window
    {
        private double lewaLiczba = 0;
        private double prawaLiczba = 0;
        private string wybraneDzialanie = "";

        private bool czyWpisujeNowaLiczbe = true;
        private bool czyPowtarzaRownaSie = false;

        public MainWindow()
        {
            InitializeComponent();
            this.Background = Brushes.White;
        }

        private void BtnDigit_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text == "Błąd") { txtDisplay.Background = Brushes.White; }

            czyPowtarzaRownaSie = false;

            Button kliknietyPrzycisk = (Button)sender;
            string cyfra = kliknietyPrzycisk.Content.ToString();

            if (czyWpisujeNowaLiczbe == true || txtDisplay.Text == "0" || txtDisplay.Text == "Błąd")
            {
                txtDisplay.Text = cyfra;
                czyWpisujeNowaLiczbe = false;
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + cyfra;
            }
        }

        private void BtnOperation_Click(object sender, RoutedEventArgs e)
        {
            lewaLiczba = double.Parse(txtDisplay.Text);

            Button kliknietyPrzycisk = (Button)sender;
            wybraneDzialanie = kliknietyPrzycisk.Content.ToString();

            czyWpisujeNowaLiczbe = true;
            czyPowtarzaRownaSie = false;
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (czyPowtarzaRownaSie == false)
            {
                prawaLiczba = double.Parse(txtDisplay.Text);
                czyPowtarzaRownaSie = true;
            }
            else
            {
                lewaLiczba = double.Parse(txtDisplay.Text);
            }

            if (wybraneDzialanie == "+") { lewaLiczba = lewaLiczba + prawaLiczba; }
            else if (wybraneDzialanie == "-") { lewaLiczba = lewaLiczba - prawaLiczba; }
            else if (wybraneDzialanie == "*") { lewaLiczba = lewaLiczba * prawaLiczba; }
            else if (wybraneDzialanie == "/")
            {
                if (prawaLiczba == 0)
                {
                    txtDisplay.Text = "Błąd";
                    txtDisplay.Background = Brushes.LightCoral;
                    czyWpisujeNowaLiczbe = true;
                    return;
                }
                lewaLiczba = lewaLiczba / prawaLiczba;
            }

            txtDisplay.Text = lewaLiczba.ToString();
            czyWpisujeNowaLiczbe = true;
        }

        private void BtnSingleOp_Click(object sender, RoutedEventArgs e)
        {
            double wartosc = double.Parse(txtDisplay.Text);
            Button kliknietyPrzycisk = (Button)sender;
            string znak = kliknietyPrzycisk.Content.ToString();

            if (znak == "√")
            {
                if (wartosc < 0) { txtDisplay.Text = "Błąd"; return; }
                wartosc = Math.Sqrt(wartosc);
            }
            else if (znak == "x²") { wartosc = Math.Pow(wartosc, 2); }
            else if (znak == "1/x")
            {
                if (wartosc == 0) { txtDisplay.Text = "Błąd"; return; }
                wartosc = 1 / wartosc;
            }

            txtDisplay.Text = wartosc.ToString();
            czyWpisujeNowaLiczbe = true;
        }

        private void BtnPercent_Click(object sender, RoutedEventArgs e)
        {
            double wartoscNaEkranie = double.Parse(txtDisplay.Text);
            double wynik = (lewaLiczba * wartoscNaEkranie) / 100;
            txtDisplay.Text = wynik.ToString();
            czyWpisujeNowaLiczbe = true;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            lewaLiczba = 0;
            prawaLiczba = 0;
            wybraneDzialanie = "";
            czyWpisujeNowaLiczbe = true;
            czyPowtarzaRownaSie = false;
            txtDisplay.Text = "0";
            txtDisplay.Background = Brushes.White;
        }

        private void BtnClearEntry_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            czyWpisujeNowaLiczbe = true;
        }

        private void BtnDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Contains(",") == false)
            {
                txtDisplay.Text = txtDisplay.Text + ",";
                czyWpisujeNowaLiczbe = false;
            }
        }

        private void BtnNegate_Click(object sender, RoutedEventArgs e)
        {
            double wartosc = double.Parse(txtDisplay.Text);
            wartosc = wartosc * -1;
            txtDisplay.Text = wartosc.ToString();
        }

        private void BtnMotyw_Click(object sender, RoutedEventArgs e)
        {

            if (this.Background == Brushes.White)
            {
                this.Background = Brushes.LightGray;
                txtDisplay.Background = Brushes.LightYellow;
            }
            else
            {
                this.Background = Brushes.White;
                txtDisplay.Background = Brushes.White;
            }
        }
    }
}
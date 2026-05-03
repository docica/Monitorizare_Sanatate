using Monitorizare_Sanatate.Data;
using Monitorizare_Sanatate.Models;
using Monitorizare_Sanatate.Models.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Monitorizare_Sanatate.UI
{
    public partial class MainWindow : Window
    {
        IStocareData adminPacienti;
        public MainWindow()
        {
           
            InitializeComponent();
            adminPacienti = StocareFactory.GetAdministratorStocare();
            AfiseazaPacienti();
            
        }
        public void AfiseazaPacienti()
        {
            List<Pacient> pacienti = adminPacienti.GetPacienti();
            lblNrPacienti.Content = $"Numar pacienti: {pacienti.Count}";
            lblPacienti.Content = "Pacienti:\n" + string.Join("\n", pacienti.Select(s => $"{s.IdPacient}: {s.Nume} {s.Prenume}"));
        }

        private int ValideazaDatePacient(string nume, string prenume, DateTime dataNasterii, string email,string telefon)
        {
            if (string.IsNullOrWhiteSpace(nume) || nume.Length>15) return 1;
            if (string.IsNullOrWhiteSpace(prenume) || prenume.Length>15) return 2;
            if (string.IsNullOrWhiteSpace(telefon) || telefon.Length!=10) return 3;
            
            return 0;
        }
        private void btnAdauga_Click( object sender, RoutedEventArgs e)
        {
            lblNume.Foreground = Brushes.Green;
            lblPrenume.Foreground = Brushes.Green;
            lblDataNasterii.Foreground = Brushes.Green;
            lblEmail.Foreground = Brushes.Green;
            lblMesajEroare.Visibility = Visibility.Collapsed;

            DateTime dataNasteriiConvertita;
            bool dataValida = DateTime.TryParse(txtDataNasterii.Text, out dataNasteriiConvertita);
            if (!dataValida)
            {
                lblDataNasterii.Foreground = Brushes.Red;
                lblMesajEroare.Text = "Format dată invalid! Folosiți AAAA/LL/ZZ.";
                lblMesajEroare.Visibility = Visibility.Visible;
                return;
            }
            lblMesajEroare.Visibility = Visibility.Collapsed;
            int eroare = ValideazaDatePacient(txtNume.Text, txtPrenume.Text,dataNasteriiConvertita,txtEmail.Text ,txtTelefon.Text);
            if(eroare!=0)
            {
                lblMesajEroare.Visibility = Visibility.Visible;
                if(eroare==1)
                {
                    txtNume.BorderBrush = Brushes.Red;
                    lblMesajEroare.Text = "Nume invalid!";
                }
                else if(eroare==2)
                {
                    txtPrenume.BorderBrush = Brushes.Red;
                    lblMesajEroare.Text = "Prenume invalid!";
                }
                else
                {
                    txtTelefon.BorderBrush = Brushes.Red;
                    lblMesajEroare.Text = "Telefon invalid!";
                }
                return;

               

            }
            Gen sexPacient = GetSelectedSex();
            List<string> simptomeSelectate = new List<string>();
            if (cbAmeteala.IsChecked == true) simptomeSelectate.Add("Amețeală");
            if (cbTremur.IsChecked == true) simptomeSelectate.Add("Tremur");
            if (cbTranspiratie.IsChecked == true) simptomeSelectate.Add("Transpirație");
            if (cbDurereDeCap.IsChecked == true) simptomeSelectate.Add("Durere de cap");
            if (cbPalpitatii.IsChecked == true) simptomeSelectate.Add("Palpitații");
            if (cbOboseala.IsChecked == true) simptomeSelectate.Add("Oboseală");
            string simptomeString = simptomeSelectate.Count > 0 ? string.Join("|", simptomeSelectate) : "Niciunul";
            int idNou = adminPacienti.GetPacienti().Count + 1;
            Pacient pacientNou = new Pacient(idNou, txtNume.Text, txtPrenume.Text,dataNasteriiConvertita,txtEmail.Text, txtTelefon.Text, sexPacient, simptomeString);
            adminPacienti.AddPacient(pacientNou);
            AfiseazaPacienti();
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtNume.Text = string.Empty;
            txtPrenume.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtNume.BorderBrush = Brushes.Gray;
            txtPrenume.BorderBrush = Brushes.Gray;
            txtTelefon.BorderBrush = Brushes.Gray;
            lblMesajEroare.Visibility = Visibility.Collapsed;
            rbNespecificat.IsChecked = true;
            cbAmeteala.IsChecked = false;
            cbTremur.IsChecked = false;
            cbTranspiratie.IsChecked = false;
            cbDurereDeCap.IsChecked = false;
            cbPalpitatii.IsChecked = false;
            cbOboseala.IsChecked = false;
        }

        private void btnMeniu_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == btnMeniuAdmin)
            {
                pnlAdministrare.Visibility = Visibility.Visible;
                pnlCautare.Visibility = Visibility.Collapsed;
            }
            else if (btn == btnMeniuCauta)
            {
                pnlAdministrare.Visibility = Visibility.Collapsed;
                pnlCautare.Visibility = Visibility.Visible;
            }
        }

        private void btnExecutaCautare_Click(object sender, RoutedEventArgs e)
        {
            string criteriu = txtCautareNume.Text.Trim().ToLower();
            var pacienti = adminPacienti.GetPacienti();
            var rezultat = pacienti.Where(p => p.Nume.ToLower().Contains(criteriu) ||
                                               p.Prenume.ToLower().Contains(criteriu)).ToList();

            if (rezultat.Any())
            {
                lblRezultatCautare.Text = "Rezultate găsite:\n" + string.Join("\n", rezultat.Select(r => r.ToString()));
                lblRezultatCautare.Foreground = Brushes.Black;
            }
            else
            {
                lblRezultatCautare.Text = "Niciun pacient găsit.";
                lblRezultatCautare.Foreground = Brushes.Red;
            }
        }

        private void Simptome_CheckedChanged(object sender, RoutedEventArgs e) {}
        private Gen GetSelectedSex()
        {

            if (rbMasculin.IsChecked == true)
                return Gen.Masculin;
            if (rbFeminin.IsChecked == true)
                return Gen.Feminin;

            return Gen.Nespecificat;
            
        }
    }
    
}
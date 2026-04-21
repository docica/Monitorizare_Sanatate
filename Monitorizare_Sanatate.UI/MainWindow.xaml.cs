using Monitorizare_Sanatate.Data;
using Monitorizare_Sanatate.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
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
         
            int idNou = adminPacienti.GetPacienti().Count + 1;
            Pacient pacientNou = new Pacient(idNou, txtNume.Text, txtPrenume.Text,dataNasteriiConvertita,txtEmail.Text, txtTelefon.Text);
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
        }
    }
    
}
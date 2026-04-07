using Monitorizare_Sanatate.Data;
using Monitorizare_Sanatate.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
namespace Monitorizare_Sanatate.UI
{
    public partial class MainWindow : Window
    {
        AdministrareStocareFisierText admin;
        public MainWindow()
        {
           
            InitializeComponent();
            admin = new AdministrareStocareFisierText(@"C:\Users\pitud\Desktop\an 2 facultate\PIU\Monitorizare_Sanatate\Monitorizare_Sanatate\bin\Debug\net8.0\pacienti.txt");
            AfiseazaPacienti();
            
        }
        public void AfiseazaPacienti()
        {
           
            try
            {
                List<Pacient> lista = admin.GetPacienti();
                ListBoxPacienti.ItemsSource = null;
                ListBoxPacienti.ItemsSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la citire: " + ex.Message);
            }

            }
    }
}
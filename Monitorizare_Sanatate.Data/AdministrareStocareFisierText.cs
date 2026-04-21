using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitorizare_Sanatate.Models;

namespace Monitorizare_Sanatate.Data
{
    public class AdministrareStocareFisierText : IStocareData
    {
        private const int ID_PRIMUL_PACIENT = 1;
        private const int INCREMENT = 1;
        private string numeFisier;

        public AdministrareStocareFisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Console.WriteLine("Fisierul se salveaza in: " + numeFisier);
            using (Stream s=File.Open(numeFisier, FileMode.OpenOrCreate)) { }
        }

        public List<Pacient> CautaDupaNume(string nume)
        {
            return GetPacienti().Where(p => p.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void AddPacient(Pacient pacient)
        {
            pacient.IdPacient = GetNextIdPacient();
            using (StreamWriter sw=new StreamWriter(numeFisier, append:true))
            {
                sw.WriteLine(pacient.ConversieLaSirPentruFisier());
            }
        }

        public List<Pacient>GetPacienti()
        {
            List<Pacient> pacienti = new List<Pacient>();
            using (StreamReader sr=new StreamReader(numeFisier))
            {
                string linie;
                while ((linie=sr.ReadLine())!=null)
                {
                    Pacient pacient = new Pacient(linie);
                    pacienti.Add(pacient);
                }
            }
            return pacienti;
        }

        public Pacient GetPacient(int idPacient)
        {
            return GetPacienti().FirstOrDefault(p => p.IdPacient == idPacient);
        }

        public Pacient GetPacient(string nume, string prenume, DateTime dataNasterii, string email, string telefon)
        {
            return GetPacienti().FirstOrDefault(p => p.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase) && p.Prenume.Equals(prenume, StringComparison.OrdinalIgnoreCase));
        }

        public bool UpdatePacient(Pacient pacient)
        {
            List<Pacient> pacienti = GetPacienti();
            bool succes = false;
            using (StreamWriter sw=new StreamWriter(numeFisier, append:false))
            {
                foreach (var p in pacienti)
                {
                    if( p.IdPacient==pacient.IdPacient)
                    {
                        sw.WriteLine(pacient.ConversieLaSirPentruFisier());
                        succes = true;
                    }
                    else
                    {
                        sw.WriteLine(p.ConversieLaSirPentruFisier());
                    }
                    
                }
            }
            return succes;
        }

        private int GetNextIdPacient()
        {
            var listaPacienti = GetPacienti();
            if (listaPacienti.Count == 0) 
                return ID_PRIMUL_PACIENT;
            return listaPacienti.Last().IdPacient + INCREMENT;
        }
    }
}

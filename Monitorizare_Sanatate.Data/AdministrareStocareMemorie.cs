using Monitorizare_Sanatate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitorizare_Sanatate.Data
{
    public class AdministrareStocareMemorie :IStocareData
    {
        private List<Pacient> pacienti = new();
        public void AddPacient(Pacient pacient)
        {
            pacienti.Add(pacient);
        }

        public List<Pacient> GetPacienti()
        {
            return new List<Pacient>(pacienti);
        }

        public List<Pacient> CautaDupaNume(string nume)
        {
            return pacienti.Where(p => p.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public Pacient GetPacient(int idPacient)
        {
            return pacienti.FirstOrDefault(p => p.IdPacient == idPacient);
        }

        public bool UpdatePacient(Pacient pacient)
        {
            return true;
        }
        public Pacient GetPacient(string nume, string prenume, DateTime dataNasterii, string email, string telefon)
        {
            return pacienti.FirstOrDefault(p => p.Nume == nume && p.Prenume == prenume);
        }
    }
}

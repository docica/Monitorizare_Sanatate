using Monitorizare_Sanatate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitorizare_Sanatate.Data
{
    public class AdministratorPacienti
    {
        private List<Pacient> pacienti = new();
        public void AdaugaPacient(Pacient pacient)
        {
            pacienti.Add(pacient);
        }

        public List<Pacient> GetAll()
        {
            return new List<Pacient>(pacienti);
        }

        public List<Pacient> CautaDupaNume(string nume)
        {
            return pacienti.Where(p => p.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

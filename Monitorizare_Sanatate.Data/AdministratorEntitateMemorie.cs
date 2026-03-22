using Monitorizare_Sanatate.Models;

namespace Monitorizare_Sanatate.Data
{
    public class AdministratorPacienti
    {
        private List<Pacient> pacienti=new();
        public void AdaugaPacient(Pacient pacient)
        {
            pacienti.Add(pacient);
        }

        public List<Pacient>GetAll()
        {
            return pacienti;
        }

        public  List<Pacient> CautaDupaNume(string nume)
        {
            return pacienti.Where(p => p.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

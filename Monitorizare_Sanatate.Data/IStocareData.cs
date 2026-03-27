using Monitorizare_Sanatate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitorizare_Sanatate.Data
{
    public interface IStocareData
    {
        void AddPacient(Pacient pacient);
        List<Pacient> GetPacienti();
        Pacient GetPacient(int idPacient);
        Pacient GetPacient(string nume, string prenume, DateTime dataNasterii, string email, string telefon);
        bool UpdatePacient(Pacient Pacient);


    }
}

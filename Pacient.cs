using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitorizare_Sanatate
{
    internal class Pacient
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Pacient(string nume, string prenume, DateTime dataNasterii, string email, string telefon)
        {
            Nume = nume;
            Prenume = prenume;
            DataNasterii = dataNasterii;
            Email = email;
            Telefon = telefon;

        }
        public override string ToString()
        {
            return $"{Nume} {Prenume}, Nascut la:{DataNasterii.ToShortDateString()}, Email: {Email}, Telefon: {Telefon} ";
        }

    }
}

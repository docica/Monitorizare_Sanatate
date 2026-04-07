using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitorizare_Sanatate.Models
{
    public class Pacient
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';
        private const bool SUCCES = true;
        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        private const int DATA_NASTERII = 3;
        private const int EMAIL = 4;
        private const int TELEFON = 5;
        public int IdPacient { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Pacient(int idPacient, string nume, string prenume, DateTime dataNasterii, string email, string telefon)
        {
            IdPacient = idPacient;
            Nume = nume;
            Prenume = prenume;
            DataNasterii = dataNasterii;
            Email = email;
            Telefon = telefon;

        }

        public Pacient(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            if (dateFisier.Length<6)
            {
                throw new Exception("Datele din fisier nu sunt complete");
            }
            this.IdPacient = int.Parse(dateFisier[ID]);
            this.Nume = dateFisier[NUME];
            this.Prenume = dateFisier[PRENUME];
            this.DataNasterii = DateTime.Parse(dateFisier[DATA_NASTERII], CultureInfo.InvariantCulture);
            this.Email = dateFisier[EMAIL];
            this.Telefon = dateFisier[TELEFON];
        }

        public string ConversieLaSirPentruFisier()
        {
                string obiectPacientPentrFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}", SEPARATOR_PRINCIPAL_FISIER,
                IdPacient.ToString(),
                (Nume ?? "NECUNOSCUT"),
                (Prenume ?? "NECUNOSCUT"),
                (DataNasterii.ToString()),
                (Email ?? "NECUNOSCUT"),
                (Telefon ?? "NECUNOSCUT"));
            return obiectPacientPentrFisier;
        }
        public override string ToString()
        {
            return $"{Nume} {Prenume}, Nascut la:{DataNasterii.ToShortDateString()}, Email: {Email}, Telefon: {Telefon} ";
        }

    }
}

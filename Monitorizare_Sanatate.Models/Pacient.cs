using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitorizare_Sanatate.Models.Enums;

namespace Monitorizare_Sanatate.Models
{
    public class Pacient
    {
        public const int LUNGIME_MAX_NUME = 15;
        public const int LUNGIME_MAX_PRENUME = 15;
        public const int CIFRE_TELEFON = 10;
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';
        private const bool SUCCES = true;
        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        private const int DATA_NASTERII = 3;
        private const int EMAIL = 4;
        private const int TELEFON = 5;
        private const int SEX = 6;     
        private const int SIMPTOME = 7;  
        public int IdPacient { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Gen Sex { get; set; }
        public string Simptome { get; set; }

        public Pacient(int idPacient, string nume, string prenume, DateTime dataNasterii, string email, string telefon, Gen sex, string simptome)
        {
            IdPacient = idPacient;
            Nume = nume;
            Prenume = prenume;
            DataNasterii = dataNasterii;
            Email = email;
            Telefon = telefon;
            this.Sex = sex;
            this.Simptome = simptome;

        }

        public Pacient(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            if (dateFisier.Length<8)
            {
                throw new Exception("Datele din fisier nu sunt complete");
            }
            this.IdPacient = int.Parse(dateFisier[ID]);
            this.Nume = dateFisier[NUME];
            this.Prenume = dateFisier[PRENUME];
            this.DataNasterii = DateTime.Parse(dateFisier[DATA_NASTERII], CultureInfo.InvariantCulture);
            this.Email = dateFisier[EMAIL];
            this.Telefon = dateFisier[TELEFON];
            this.Sex = (Gen)Enum.Parse(typeof(Gen), dateFisier[SEX]);
            this.Simptome = dateFisier[SIMPTOME];
        }

        public string ConversieLaSirPentruFisier()
        {
                string obiectPacientPentrFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}", SEPARATOR_PRINCIPAL_FISIER,
                IdPacient.ToString(),
                Nume ?? "NECUNOSCUT",
                Prenume ?? "NECUNOSCUT",
                DataNasterii.ToString(),
                Email ?? "NECUNOSCUT",
                Telefon ?? "NECUNOSCUT",
                (int)Sex,
                Simptome ?? "Niciunul");
            return obiectPacientPentrFisier;
        }
        public override string ToString()
        {
            return $"{Nume} {Prenume}, Nascut la:{DataNasterii.ToShortDateString()}, Email: {Email}, Telefon: {Telefon} ";
        }

    }
}

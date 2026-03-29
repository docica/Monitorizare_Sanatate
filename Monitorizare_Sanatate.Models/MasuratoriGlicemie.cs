using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitorizare_Sanatate.Models
{
    public class MasuratoriGlicemie
    {
        public DateTime DataMasurare { get; set; }
        public double ValoareGlicemie { get; set; }
        public string UnitateMasura { get; set; }
        public Pacient Pacient { get; set; }
        public MasuratoriGlicemie(DateTime dataMasurare, double valoareGlicemie, string unitateMasura, Pacient pacient)
        {
            DataMasurare = dataMasurare;
            ValoareGlicemie = valoareGlicemie;
            UnitateMasura = unitateMasura;
            Pacient = pacient;
        }
        public override string ToString()
        {
            return $"Data Masurare: {DataMasurare.ToShortDateString()},Glicemie: {ValoareGlicemie} {UnitateMasura}, Pacient: {Pacient.Nume} {Pacient.Prenume}";
        }

        public MasuratoriGlicemie() { }
    }
}

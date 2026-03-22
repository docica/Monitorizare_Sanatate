using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitorizare_Sanatate.Models
{
    public class MasuratoriCardiovasculare
    {
        public DateTime DataMasurare { get; set; }
        public int TensiuneaSistolica { get; set; }
        public int TensiuneaDiastolica { get; set; }
        public int Puls { get; set; }
        public Pacient Pacient { get; set; }
        public MasuratoriCardiovasculare(DateTime dataMasurare, int tensiuneaSistolica, int tensiuneaDiastolica, int puls, Pacient pacient)
        {
            DataMasurare = dataMasurare;
            TensiuneaDiastolica = tensiuneaDiastolica;
            TensiuneaSistolica = tensiuneaSistolica;
            Puls = puls;
            Pacient = pacient;
        }
        public override string ToString()
        {
            return $"Data Masurare:{DataMasurare.ToShortDateString()},Tensiune:{TensiuneaSistolica} / {TensiuneaDiastolica},Puls:{Puls}, Pacient: {Pacient}  ";
        }

    }
}

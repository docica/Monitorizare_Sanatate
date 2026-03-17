using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitorizare_Sanatate
{
    internal class SistemeAlerta
    {
        public string VerificareGlicemie(MasuratoriGlicemie masuratori)
        {
            if (masuratori.ValoareGlicemie<70)
            {
                return $"Alerta! Glicemie scazuta pentru pacientul {masuratori.Pacient.Nume} {masuratori.Pacient.Prenume}. Valoare:{masuratori.ValoareGlicemie} {masuratori.UnitateMasura}";

            }
            else if (masuratori.ValoareGlicemie>180)
            {
                return $"Alerta! Glicemie crescuta pentru pacientul {masuratori.Pacient.Nume} {masuratori.Pacient.Prenume}. Valoare: {masuratori.ValoareGlicemie} {masuratori.UnitateMasura}";

            }
            return $"Glicemie normala pentru pacientul {masuratori.Pacient.Nume} {masuratori.Pacient.Prenume}. Valoare:{masuratori.ValoareGlicemie} {masuratori.UnitateMasura}";
        }

        public string VerificareTensiune(MasuratoriCardiovasculare masuratori)
        {
            if (masuratori.TensiuneaSistolica>140 || masuratori.TensiuneaDiastolica>90 )
            {
                return $"Alerta! Tensiune arteriala crescuta pentru pacientul {masuratori.Pacient.Nume} {masuratori.Pacient.Prenume}. Valoare: {masuratori.TensiuneaSistolica}/{masuratori.TensiuneaDiastolica} mmHg";
            }
            else if (masuratori.TensiuneaSistolica<90 || masuratori.TensiuneaDiastolica<60)
            {
                return $"Alerta!Tensiune arteriala scazuta pentru pacientul {masuratori.Pacient.Nume} {masuratori.Pacient.Prenume}. Valoare: {masuratori.TensiuneaSistolica}/{masuratori.TensiuneaDiastolica} mmHg";

            }
            return $"Tensiune arteriala normala pentru pacientul {masuratori.Pacient.Nume} {masuratori.Pacient.Prenume}. Vaaloare:{masuratori.TensiuneaSistolica}/{masuratori.TensiuneaDiastolica} mmHg";
        }


        public string VerificarePuls(MasuratoriCardiovasculare masuratori)
        {
            if(masuratori.Puls>100)
            {
                return $"Alerta!Puls crescut pentru pacientul {masuratori.Pacient.Nume} {masuratori.Pacient.Prenume}. Valoare:{masuratori.Puls}bpm";


            }
            else if(masuratori.Puls<60)
            {
                return $"Alerta!Puls scazut pentru pacientul {masuratori.Pacient.Nume} {masuratori.Pacient.Prenume}. Valoare:{masuratori.Puls}bpm";
            }
            return $"Puls normal pentru pacientul {masuratori.Pacient.Nume} {masuratori.Pacient.Prenume}. Valoare:{masuratori.Puls}bpm";
        }
        
    }
}

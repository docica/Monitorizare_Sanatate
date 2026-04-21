using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitorizare_Sanatate.Data;
using System.Configuration;

namespace Monitorizare_Sanatate
{
    public static class StocareFactory
    {
        private const string FORMAT_SALVARE = "FormatSalvare";
        private const string NUME_FISIER = "NumeFisier";

        public static IStocareData GetAdministratorStocare()
        {
            string formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE] ?? "";
            string numeFisier = ConfigurationManager.AppSettings[NUME_FISIER] ?? "";
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName ?? "";
            string caleCompletaFisier = "pacienti.txt";
            if(formatSalvare!=null)
            {
                switch(formatSalvare)
                {
                    default:
                    case "memorie":
                        return new AdministrareStocareMemorie();
                    case "txt":
                        return new AdministrareStocareFisierText(caleCompletaFisier + "." + formatSalvare);

                }
            }
            return null;
        }
    }
}

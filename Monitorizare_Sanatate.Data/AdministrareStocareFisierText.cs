using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitorizare_Sanatate.Data
{
    public class AdministrareStocareFisierText : IStocareData
    {
        private string numeFisier;

        public AdministrareStocareFisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
        }

    }
}

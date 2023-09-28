using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trein
{
    internal class Rit
    {
        public Rit(string naarLocatie)
        {
            NaarLocatie = naarLocatie;
            Datum = DateTime.Today;
        }


        #region Properties

        public string NaarLocatie { get; private set; }
        public DateTime Datum { get; private set; }


        #endregion
    }
}

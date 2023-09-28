using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Trein
{
    internal class EnkelTicket: IKaart
    {
        #region Members

        public DateTime Datum { get => _datum; }
        private DateTime _datum;
        private string _vanLocatie;
        private string _naarLocatie;

        #endregion

        public EnkelTicket(DateTime datum, string vanLocatie, string naarLocatie)
        {
            _datum = datum;
            _vanLocatie = vanLocatie;
            _naarLocatie = naarLocatie;
            Id = new Random().Next().ToString();
        }

        #region Properties

        public string VanLocatie { get => _vanLocatie; }
        public string NaarLocatie { get => _naarLocatie; }

        public string Id { get; }

        #endregion

        public bool IsValid(string[] route)
        {
            // Huidige datum correct
            if (Datum != DateTime.Today)
            {
                return false;
            }

            // Van en naar locatie liggen op route
            if (!route.Contains(VanLocatie) || !route.Contains(NaarLocatie))
            {
                return false;
            }

            // Zelfde check als hierboven 

            if (!(route.Contains(VanLocatie) && route.Contains(NaarLocatie)))
            {
                return false;
            }

            // Van locatie < naar locatie
            int indexVanLocatie = route.ToList().IndexOf(VanLocatie);
            int indexNaarLocatie = route.ToList().IndexOf(NaarLocatie);

            if (indexVanLocatie > indexNaarLocatie)
            {
                return false;
            }


            return true;
        }
    }
}

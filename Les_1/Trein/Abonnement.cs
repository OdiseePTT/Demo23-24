using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trein
{
    internal class Abonnement : IKaart
    {
        public Abonnement(DateTime geldigVan, DateTime geldigTot, string vanLocatie, string naarLocatie) {
        
            GeldigVan = geldigVan;
            GeldigTot = geldigTot;
            VanLocatie = vanLocatie;
            NaarLocatie = naarLocatie;
        }

        #region Properties

        public DateTime GeldigVan { get; private set; }
        public DateTime GeldigTot { get; private set; }
        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }

        public string Id => throw new NotImplementedException();

        public bool IsValid(string[] route)
        {
           
                // Check date
                if (!(GeldigVan <= DateTime.Today && GeldigTot >= DateTime.Today))
                {
                    return false;
                }


                // Van en naar locatie liggen op route
                if (!(route.Contains(VanLocatie) && route.Contains(NaarLocatie)))
                {
                    return false;
                }

                return true;
            
        }

        #endregion
    }
}

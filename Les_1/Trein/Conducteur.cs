using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Trein
{
    internal class Conducteur
    {
        private string[] _route;

        public Conducteur(string[] route)
        {
            _route = route;
        }

        #region Public Methods

        public bool CheckKaart(IKaart kaart)
        {
            return kaart.IsValid(_route);
        }

        #endregion


    }
}

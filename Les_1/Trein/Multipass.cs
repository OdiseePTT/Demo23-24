namespace Trein
{


    internal class Multipass : IKaart
    {
        const int AANTAL_RITTEN = 10;

        public Multipass(string vanLocatie, string naarLocatie)
        {
            VanLocatie = vanLocatie;
            NaarLocatie = naarLocatie;
            Ritten = new Rit[AANTAL_RITTEN];
        }

        #region Properties

        public string VanLocatie { get; private set; }
        public string NaarLocatie { get; private set; }
        public Rit?[] Ritten { get; private set; }

        public string Id => throw new NotImplementedException();



        #endregion

        #region Public methods
        public bool IsValid(string[] route)
        {
            Rit laatsteRit = GeefLaatsteRit();

            if (laatsteRit == null)
            {
                return false;
            }
            // currentDate
            if (laatsteRit.Datum != DateTime.Today)
            {
                return false;
            }

            // Van en naar locatie liggen op route
            if (!(route.Contains(VanLocatie) && route.Contains(NaarLocatie)))
            {
                return false;
            }
            // Van locatie < naar locatie
            string naarLocatie = laatsteRit.NaarLocatie;
            string vanLocatie = NaarLocatie == naarLocatie ? VanLocatie : NaarLocatie;
            int indexVanLocatie = route.ToList().IndexOf(vanLocatie);
            int indexNaarLocatie = route.ToList().IndexOf(naarLocatie);

            if (indexVanLocatie > indexNaarLocatie)
            {
                return false;
            }

            return true;

        }
        public bool RitToevoegen(string naarLocatie)
        {


            int i = 0;

            while (i < AANTAL_RITTEN && Ritten[i] != null)
            {
                i++;
            }

            if (i >= AANTAL_RITTEN)
            {
                return false;
            }


            Rit rit = new Rit(naarLocatie);
            Ritten[i] = rit;

            return true;
        }

        #endregion
        private Rit? GeefLaatsteRit()
        {
            int i = 0;
            Rit? laatsteRit = null;
            while (i < Ritten.Length && Ritten[i] != null)
            {
                laatsteRit = Ritten[i];
                i++;
            }

            return laatsteRit;
        }

    }
}

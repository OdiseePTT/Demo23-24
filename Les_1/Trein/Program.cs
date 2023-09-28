namespace Trein
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] route = new string[] { "Gent", "Aalst", "Denderleeuw", "Brussel" };

            EnkelTicket enkelTicket = new EnkelTicket(DateTime.Today, "Gent", "Brussel");
            Multipass multipass = new Multipass("Brussel", "Aalst");
            multipass.RitToevoegen("Brussel");

            Abonnement abonnement = new Abonnement(DateTime.Today.AddMonths(-5), DateTime.Today.AddMonths(5), "Denderleeuw", "Aalst");

            Conducteur conducteur = new Conducteur(route);

      

            Console.WriteLine(conducteur.CheckKaart(enkelTicket));
            Console.WriteLine(conducteur.CheckKaart(multipass));
            Console.WriteLine(conducteur.CheckKaart(abonnement));

        }
    }
}
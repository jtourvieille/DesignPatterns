using System;
using System.Collections.Generic;

namespace DP.Behavioral.ChainOfResp
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstApprover = SetupChainOfResponsibility();

            var demandes = GenerateRandomDemandes();
            foreach (var demandeAugmentation in demandes)
            {
                firstApprover.EtudieDemandeAugmentation(demandeAugmentation);
            }
        }

        private static IEnumerable<DemandeAugmentation> GenerateRandomDemandes()
        {
            var rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                yield return new DemandeAugmentation
                {
                    Demandeur = "Jean Charles S",
                    Pourcentage = rnd.Next(1, 31)
                };
            }
        }

        private static Approver SetupChainOfResponsibility()
        {
            Approver christopheM = new Manager();
            Approver thomasC = new ResponsableDepartement();
            Approver jeanPhilippeE = new ResponsableDirection();
            Approver davidGdeS = new Dsi();
            Approver jacquesDeP = new Pdg();

            christopheM.SetSuccessor(thomasC);
            thomasC.SetSuccessor(jeanPhilippeE);
            jeanPhilippeE.SetSuccessor(davidGdeS);
            davidGdeS.SetSuccessor(jacquesDeP);

            return christopheM;
        }
    }
}

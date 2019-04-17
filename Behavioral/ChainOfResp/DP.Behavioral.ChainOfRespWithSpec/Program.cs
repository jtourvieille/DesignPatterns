using System;
using System.Collections.Generic;

namespace DP.Behavioral.ChainOfRespWithSpec
{
    class Program
    {
        static void Main(string[] args)
        {
            var demandes = GenerateRandomDemandes();

            foreach (var demandeAugmentation in demandes)
            {
                var firstApprover = SetupChainOfResponsibility(demandeAugmentation.Division);

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
                    Pourcentage = rnd.Next(1, 31),
                    CrvPourcentage = rnd.Next(60, 120),
                    Division = rnd.Next(0, 2) > 0 ? Division.CollectivesSante : Division.Iard
                };
            }
        }

        private static Approver<DemandeAugmentation> SetupChainOfResponsibility(Division division)
        {
            ISpecification<DemandeAugmentation> lessThan3Percent =
                new Specification<DemandeAugmentation>(d => d.Pourcentage <= 3);

            ISpecification<DemandeAugmentation> moreThan3Percent =
                new Specification<DemandeAugmentation>(d=>d.Pourcentage > 3);
            
            ISpecification<DemandeAugmentation> lessThan5Percent =
                new Specification<DemandeAugmentation>(d => d.Pourcentage <= 5);

            ISpecification<DemandeAugmentation> moreThan5Percent =
                new Specification<DemandeAugmentation>(d => d.Pourcentage > 5);

            ISpecification<DemandeAugmentation> lessThan8Percent =
                new Specification<DemandeAugmentation>(d => d.Pourcentage <= 8);

            ISpecification<DemandeAugmentation> moreThan8Percent =
                new Specification<DemandeAugmentation>(d => d.Pourcentage > 8);

            ISpecification<DemandeAugmentation> lessThan15Percent =
                new Specification<DemandeAugmentation>(d => d.Pourcentage <= 15);

            ISpecification<DemandeAugmentation> moreThan15Percent =
                new Specification<DemandeAugmentation>(d => d.Pourcentage > 15);

            ISpecification<DemandeAugmentation> lessThan20Percent =
                new Specification<DemandeAugmentation>(d => d.Pourcentage <= 20);

            ISpecification<DemandeAugmentation> moreThan20Percent =
                new Specification<DemandeAugmentation>(d => d.Pourcentage > 20);

            Approver<DemandeAugmentation> christopheM = new Manager<DemandeAugmentation>();
            Approver<DemandeAugmentation> thomasC = new ResponsableDepartement<DemandeAugmentation>();
            Approver<DemandeAugmentation> jeanPhilippeE = new ResponsableDirection<DemandeAugmentation>();
            Approver<DemandeAugmentation> davidGdeS = new Dsi<DemandeAugmentation>();
            Approver<DemandeAugmentation> jacquesDeP = new Pdg<DemandeAugmentation>();

            christopheM.SetSuccessor(thomasC);
            thomasC.SetSuccessor(jeanPhilippeE);
            jeanPhilippeE.SetSuccessor(davidGdeS);
            davidGdeS.SetSuccessor(jacquesDeP);

            christopheM.SetSpecification(lessThan3Percent);
            thomasC.SetSpecification(moreThan3Percent.And(lessThan5Percent));
            jeanPhilippeE.SetSpecification(moreThan5Percent.And(lessThan8Percent));
            davidGdeS.SetSpecification(moreThan8Percent.And(lessThan15Percent));

            if (division == Division.CollectivesSante)
            {
                jacquesDeP.SetSpecification(moreThan15Percent);
            }
            else if (division == Division.Iard)
            {
                jacquesDeP.SetSpecification(moreThan15Percent.And(lessThan20Percent));

                Approver<DemandeAugmentation> thomasB = new DirecteurHolding<DemandeAugmentation>();

                jacquesDeP.SetSuccessor(thomasB);

                thomasB.SetSpecification(moreThan20Percent);
            }

            return christopheM;
        }
    }
}

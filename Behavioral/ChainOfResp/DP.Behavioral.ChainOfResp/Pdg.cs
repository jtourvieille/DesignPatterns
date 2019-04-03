using System;

namespace DP.Behavioral.ChainOfResp
{
    internal class Pdg : Approver
    {
        public override void EtudieDemandeAugmentation(DemandeAugmentation demandeAugmentation)
        {
            this.TraiteDemandeAugmentation(demandeAugmentation);
        }

        private void TraiteDemandeAugmentation(DemandeAugmentation demandeAugmentation)
        {
            Random random = new Random();
            var randomizedNumber = random.Next(0, 101);

            Console.WriteLine(randomizedNumber < 30
                ? $"{demandeAugmentation.Demandeur}, votre {this.GetType().Name} a approuvé votre demande d'augmentation de {demandeAugmentation.Pourcentage}%. Félicitations."
                : $"{demandeAugmentation.Demandeur}, votre {this.GetType().Name} n'a pas approuvé votre demande d'augmentation de {demandeAugmentation.Pourcentage}%. Retentez votre chance.");
        }
    }
}
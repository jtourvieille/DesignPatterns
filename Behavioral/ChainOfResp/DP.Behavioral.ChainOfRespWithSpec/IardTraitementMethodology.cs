using System;

namespace DP.Behavioral.ChainOfRespWithSpec
{
    internal class IardTraitementMethodology : ITraitementMethodology
    {
        public bool IsAugmentationAccordee(DemandeAugmentation demandeAugmentation, double facteurChance)
        {
            Random random = new Random();
            bool augmentationAccordee;

            if (demandeAugmentation.CrvPourcentage < 90)
            {
                augmentationAccordee = false;
            }
            else
            {
                var chanceSupplementaire = this.GetChanceSupplementaire(demandeAugmentation.CrvPourcentage);

                var randomizedNumber = random.Next(0, 101);

                augmentationAccordee = randomizedNumber < (facteurChance + facteurChance * chanceSupplementaire);
            }

            return augmentationAccordee;
        }

        private double GetChanceSupplementaire(double demandeAugmentationCrvPourcentage)
        {
            if (demandeAugmentationCrvPourcentage <= 99 && demandeAugmentationCrvPourcentage >= 90)
            {
                return 0.25;
            }

            return 0.5;
        }
    }
}
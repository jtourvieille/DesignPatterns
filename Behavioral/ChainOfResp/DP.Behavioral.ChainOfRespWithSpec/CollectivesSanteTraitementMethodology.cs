using System;

namespace DP.Behavioral.ChainOfRespWithSpec
{
    internal class CollectivesSanteTraitementMethodology : ITraitementMethodology
    {
        public bool IsAugmentationAccordee(DemandeAugmentation demandeAugmentation, double facteurChance)
        {
            Random random = new Random();
            var randomizedNumber = random.Next(0, 101);

            return randomizedNumber < facteurChance;
        }
    }
}
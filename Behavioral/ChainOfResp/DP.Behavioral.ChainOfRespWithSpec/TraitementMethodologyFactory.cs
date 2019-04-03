using System;

namespace DP.Behavioral.ChainOfRespWithSpec
{
    internal static class TraitementMethodologyFactory
    {
        public static ITraitementMethodology GeTraitementMethodology(DemandeAugmentation demandeAugmentation)
        {
            switch (demandeAugmentation.Division)
            {
                case Division.Iard:
                        return new IardTraitementMethodology();
                case Division.CollectivesSante:
                    return new CollectivesSanteTraitementMethodology();
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}

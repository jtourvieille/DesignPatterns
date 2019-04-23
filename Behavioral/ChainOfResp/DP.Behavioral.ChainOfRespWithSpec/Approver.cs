using System;

namespace DP.Behavioral.ChainOfRespWithSpec
{
    internal abstract class Approver<T> where T : DemandeAugmentation
    {
        private Approver<T> successor;
        private ISpecification<T> specification;

        public void SetSuccessor(Approver<T> successor)
        {
            this.successor = successor;
        }

        public void SetSpecification(ISpecification<T> specification)
        {
            this.specification = specification;
        }

        private bool PeutTraiter(T demande)
        {
            return this.specification.IsSatisfiedBy(demande);
        }

        public void EtudieDemandeAugmentation(DemandeAugmentation demandeAugmentation)
        {
            if (this.PeutTraiter(demandeAugmentation as T))
            {
                this.TraiteDemandeAugmentation(demandeAugmentation);
            }
            else
            {
                this.successor?.EtudieDemandeAugmentation(demandeAugmentation);
            }
        }

        // Compris entre 50 et 25 selon le palier
        protected abstract double FacteurChance { get; }

        protected string NiveauHierarchique => this.GetType().Name;

        private void TraiteDemandeAugmentation(DemandeAugmentation demandeAugmentation)
        {
            var traitementMethodology =
                TraitementMethodologyFactory.GetTraitementMethodology(demandeAugmentation);

            bool augmentationAccordee =
                traitementMethodology.IsAugmentationAccordee(demandeAugmentation, FacteurChance);

            Console.WriteLine(augmentationAccordee
                ? $"{demandeAugmentation.Demandeur} ({demandeAugmentation.Division.ToString()} - {demandeAugmentation.CrvPourcentage}), votre {this.NiveauHierarchique} a approuvé votre demande d'augmentation de {demandeAugmentation.Pourcentage}%. Félicitations."
                : $"{demandeAugmentation.Demandeur} ({demandeAugmentation.Division.ToString()} - {demandeAugmentation.CrvPourcentage}), votre {this.NiveauHierarchique} n'a pas approuvé votre demande d'augmentation de {demandeAugmentation.Pourcentage}%. Retentez votre chance.");
        }

        private void TraiteCollectivesSanteDemande(DemandeAugmentation demandeAugmentation)
        {
            Random random = new Random();
            var randomizedNumber = random.Next(0, 101);

            Console.WriteLine(randomizedNumber < FacteurChance
                ? $"{demandeAugmentation.Demandeur} ({demandeAugmentation.Division.ToString()} - {demandeAugmentation.CrvPourcentage}), votre {this.NiveauHierarchique} a approuvé votre demande d'augmentation de {demandeAugmentation.Pourcentage}%. Félicitations."
                : $"{demandeAugmentation.Demandeur} ({demandeAugmentation.Division.ToString()} - {demandeAugmentation.CrvPourcentage}), votre {this.NiveauHierarchique} n'a pas approuvé votre demande d'augmentation de {demandeAugmentation.Pourcentage}%. Retentez votre chance.");
        }

        

        
    }
}

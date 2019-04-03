namespace DP.Behavioral.ChainOfResp
{
    internal abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract void EtudieDemandeAugmentation(DemandeAugmentation demandeAugmentation);
    }
}

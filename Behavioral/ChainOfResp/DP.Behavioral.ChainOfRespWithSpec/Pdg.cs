namespace DP.Behavioral.ChainOfRespWithSpec
{
    internal class Pdg<T> : Approver<T> where T : DemandeAugmentation
    {
        protected override double FacteurChance => 30;
    }
}

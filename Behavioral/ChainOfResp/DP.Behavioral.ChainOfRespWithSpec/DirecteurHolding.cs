namespace DP.Behavioral.ChainOfRespWithSpec
{
    internal class DirecteurHolding<T> : Approver<T> where T : DemandeAugmentation
    {
        protected override double FacteurChance => 25;
    }
}

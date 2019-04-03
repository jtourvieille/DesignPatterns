namespace DP.Behavioral.ChainOfRespWithSpec
{
    internal class Manager<T> : Approver<T> where T: DemandeAugmentation
    {
        protected override double FacteurChance => 50;
    }
}

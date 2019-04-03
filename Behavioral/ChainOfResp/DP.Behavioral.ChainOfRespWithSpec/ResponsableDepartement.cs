namespace DP.Behavioral.ChainOfRespWithSpec
{
    internal class ResponsableDepartement<T> : Approver<T> where T : DemandeAugmentation
    {
        protected override double FacteurChance => 45;
    }
}

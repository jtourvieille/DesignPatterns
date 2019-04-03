namespace DP.Behavioral.ChainOfRespWithSpec
{
    internal class ResponsableDirection<T> : Approver<T> where T : DemandeAugmentation
    {
        protected override double FacteurChance => 40;
    }
}

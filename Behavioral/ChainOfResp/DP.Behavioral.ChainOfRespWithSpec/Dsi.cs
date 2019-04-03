namespace DP.Behavioral.ChainOfRespWithSpec
{
    internal class Dsi<T> : Approver<T> where T : DemandeAugmentation
    {
        protected override double FacteurChance => 35;
    }
}

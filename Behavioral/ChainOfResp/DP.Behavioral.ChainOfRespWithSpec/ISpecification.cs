namespace DP.Behavioral.ChainOfRespWithSpec
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T o);
    }
}

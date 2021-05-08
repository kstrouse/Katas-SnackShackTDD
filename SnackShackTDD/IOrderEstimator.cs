namespace SnackShackTDD
{
    public interface IOrderEstimator
    {
        void AddSandwiches(int sandwichCount);
        int GetEstimate();
    }
}

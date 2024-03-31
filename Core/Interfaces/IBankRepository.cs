namespace Core.Interfaces
{
    public interface IBankRepository
    {
        public Task<bool> MoveAmount(Tuple<Guid, double> from, Tuple<Guid, double > to);
    }
}
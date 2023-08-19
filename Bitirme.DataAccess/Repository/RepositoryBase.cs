namespace Bitirme.DataAccess.Repository
{
    public abstract class RepositoryBase<T> where T : class
    {
        public abstract T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter);
    }
}
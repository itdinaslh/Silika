using Silika.Entity;

namespace Silika.Repository
{
    public interface IStatusLahan
    {
        IQueryable<StatusLahan> StatusLahans { get; }

        Task SaveDataAsync(StatusLahan status);

    }
}

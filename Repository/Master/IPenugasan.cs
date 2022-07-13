using Silika.Entity;

namespace Silika.Repository
{
    public interface IPenugasan
    {
        IQueryable<Penugasan> Penugasans { get; }

        Task SaveDataAsync(Penugasan tugas);
    }
}

using Silika.Entity;

namespace Silika.Repository;

public interface ITps
{
    IQueryable<Tps> Tps { get; }

    Task SaveDataAsync(Tps tps);
}

using Silika.Entity;

namespace Silika.Repository;

public interface IJenisTpsRepo {
    IQueryable<JenisTps> JenisTps { get; }

    Task SaveDataAsync(JenisTps jenis);
}
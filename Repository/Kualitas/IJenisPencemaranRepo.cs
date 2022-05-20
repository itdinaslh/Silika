using Silika.Entity;

namespace Silika.Repository;

public interface IJenisPencemaranRepo {
    IQueryable<JenisPencemaran> JenisPencemarans { get; }

    Task SaveDataAsync(JenisPencemaran jenis);
}
using Silika.Entity;

namespace Silika.Repository;

public interface IJenisWrRepo {
    IQueryable<JenisWr> JenisWrs { get; }

    Task SaveDataAsync(JenisWr jenis);
}
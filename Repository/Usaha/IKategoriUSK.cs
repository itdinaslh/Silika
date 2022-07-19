using Silika.Entity;

namespace Silika.Repository;

public interface IKategoriUSK {
    IQueryable<KategoriUSK> KategoriUSKs { get; }

    Task SaveDataAsync(KategoriUSK kat);
}
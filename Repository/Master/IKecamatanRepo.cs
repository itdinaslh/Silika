using Silika.Entity;

namespace Silika.Repository;

public interface IKecamatanRepo {
    IQueryable<Kecamatan> Kecamatans { get; }
}
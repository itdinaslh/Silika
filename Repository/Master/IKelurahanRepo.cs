using Silika.Entity;

namespace Silika.Repository;

public interface IKelurahanRepo {
    IQueryable<Kelurahan> Kelurahans { get; }
}
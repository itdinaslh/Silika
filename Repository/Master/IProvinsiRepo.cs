using Silika.Entity;

namespace Silika.Repository;

public interface IProvinsiRepo {
    public IQueryable<Provinsi> Provinsis { get; }
}
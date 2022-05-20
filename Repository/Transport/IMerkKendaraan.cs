using Silika.Entity;

namespace Silika.Repository;

public interface IMerkKendaraan {
    IQueryable<MerkKendaraan> MerkKendaraans { get; }

    Task SaveDataAsync(MerkKendaraan merk);
}
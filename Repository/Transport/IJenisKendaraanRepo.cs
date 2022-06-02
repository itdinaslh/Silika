using Silika.Entity;

namespace Silika.Repository;

public interface IJenisKendaraanRepo {
    IQueryable<JenisKendaraan> JenisKendaraans { get; }

    Task SaveDataAsync(JenisKendaraan jenisKendaraan);
}
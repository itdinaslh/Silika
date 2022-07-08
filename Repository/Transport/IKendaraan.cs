using Silika.Entity;

namespace Silika.Repository;

public interface IKendaraan
{
    IQueryable<Kendaraan> Kendaraans { get; }

    Task SaveDataAsync(Kendaraan kendaraan);
}
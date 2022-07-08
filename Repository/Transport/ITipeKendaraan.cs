using Silika.Entity;

namespace Silika.Repository;

public interface ITipeKendaraan
{
    IQueryable<TipeKendaraan> TipeKendaraans { get; }

    Task SaveDataAsync(TipeKendaraan tipe);
}

using Silika.Entity;

namespace Silika.Repository;

public interface IPegawai
{
    IQueryable<Pegawai> Pegawais { get; }

    Task SaveDataAsync(Pegawai peg);
}
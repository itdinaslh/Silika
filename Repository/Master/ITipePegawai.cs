using Silika.Entity;

namespace Silika.Repository;

public interface ITipePegawai
{
    IQueryable<TipePegawai> TipePegawais { get; }
}

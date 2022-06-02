using Silika.Entity;

namespace Silika.Repository;

public interface IBidangRepo {
    IQueryable<Bidang> Bidangs { get; }

    Task SaveBidangAsync(Bidang bidang);
}
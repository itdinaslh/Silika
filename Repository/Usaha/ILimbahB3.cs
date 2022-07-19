using Silika.Entity;

namespace Silika.Repository;

public interface ILimbahB3 {
    IQueryable<LimbahB3> LimbahB3s { get; }

    Task SaveDataAsync(LimbahB3 limbah);
}
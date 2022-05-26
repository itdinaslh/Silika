using Silika.Entity;

namespace Silika.Repository;

public interface IKabupatenRepo {
    IQueryable<Kabupaten> Kabupatens { get; }
}
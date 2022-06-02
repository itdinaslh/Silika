using Silika.Entity;

namespace Silika.Repository;

public interface INilaiPencemaranRepo {
    IQueryable<NilaiPencemaran> NilaiPencemarans { get; }

    Task SaveDataAsync(NilaiPencemaran nilai);
}
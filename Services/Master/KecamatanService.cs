using Silika.Entity;
using Silika.Data;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class KecamatanService : IKecamatanRepo {
    private AppDbContext context;

    public KecamatanService(AppDbContext ctx) => context = ctx;

    public IQueryable<Kecamatan> Kecamatans => context.Kecamatans;
}
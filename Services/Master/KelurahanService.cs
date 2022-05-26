using Silika.Entity;
using Silika.Repository;
using Silika.Data;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class KelurahanService : IKelurahanRepo {
    private AppDbContext context;

    public KelurahanService(AppDbContext ctx) => context = ctx;

    public IQueryable<Kelurahan> Kelurahans => context.Kelurahans;
}
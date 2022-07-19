using Silika.Data;
using Silika.Entity;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class KategoriUSKService : IKategoriUSK {
    private readonly AppDbContext context;

    public KategoriUSKService(AppDbContext ctx) => context = ctx;

    public IQueryable<KategoriUSK> KategoriUSKs => context.KategoriUSKs;

    public async Task SaveDataAsync(KategoriUSK kat) {
        if (kat.KategoriUSKId == 0) {
            await context.AddAsync(kat);
        } else {
            KategoriUSK? data = await context.KategoriUSKs.FindAsync(kat.KategoriUSKId);

            if (data is not null) {
                data.KodeKategori = kat.KodeKategori;
                data.NamaKategori = kat.NamaKategori;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}
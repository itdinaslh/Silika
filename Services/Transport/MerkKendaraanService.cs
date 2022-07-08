using Silika.Entity;
using Silika.Data;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class MerkKendaraanService : IMerkKendaraan {
    private AppDbContext context;

    public MerkKendaraanService(AppDbContext ctx) => context = ctx;

    public IQueryable<MerkKendaraan> MerkKendaraans => context.MerkKendaraans;

    #nullable disable
    public async Task SaveDataAsync(MerkKendaraan merk) {
        if (merk.MerkKendaraanId == 0) {
            await context.AddAsync(merk);
        } else {
            MerkKendaraan m = await context.MerkKendaraans.FirstOrDefaultAsync(m => m.MerkKendaraanId == merk.MerkKendaraanId);
            m.NamaMerk = merk.NamaMerk;
            m.KodeMerk = merk.KodeMerk;
            m.UpdatedAt = DateTime.Now;

            context.Update(m);
        }

        await context.SaveChangesAsync();
    }
}
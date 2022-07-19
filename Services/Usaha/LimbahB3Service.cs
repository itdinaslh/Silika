using Silika.Entity;
using Silika.Data;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class LimbahB3Service : ILimbahB3 {
    private readonly AppDbContext context;

    public LimbahB3Service(AppDbContext ctx) => context = ctx;

    public IQueryable<LimbahB3> LimbahB3s => context.LimbahB3s;

    public async Task SaveDataAsync(LimbahB3 limbah) {
        if (limbah.LimbahB3Id == 0) {
            await context.AddAsync(limbah);
        } else {
            LimbahB3? data = await context.LimbahB3s.FindAsync(limbah.LimbahB3Id);

            if (data is not null) {
                data.KodeLimbah = limbah.KodeLimbah;
                data.NamaLimbah = limbah.NamaLimbah;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}
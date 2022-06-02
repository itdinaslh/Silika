using Silika.Entity;
using Silika.Data;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class JenisTpsService : IJenisTpsRepo {
    private AppDbContext context;

    public JenisTpsService(AppDbContext ctx) => context = ctx;

    public IQueryable<JenisTps> JenisTps => context.JenisTps;

    #nullable disable
    public async Task SaveDataAsync(JenisTps jenis) {
        if (jenis.JenisID == 0) {
            await context.AddAsync(jenis);
        } else {
            JenisTps jns = await context.JenisTps.FirstOrDefaultAsync(j => j.JenisID == jenis.JenisID);
            jns.NamaJenis = jenis.NamaJenis.Trim();

            context.Update(jns);
        }

        await context.SaveChangesAsync();
    }
}
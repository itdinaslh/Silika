using Silika.Entity;
using Silika.Data;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class JenisPencemaranService : IJenisPencemaranRepo {
    private AppDbContext context;

    public JenisPencemaranService(AppDbContext ctx) => context = ctx;

    public IQueryable<JenisPencemaran> JenisPencemarans => context.JenisPencemarans;

    #nullable disable
    public async Task SaveDataAsync(JenisPencemaran jenis) {
        if (jenis.JenisID == 0) {
            await context.AddAsync(jenis);
        } else {
            JenisPencemaran jns = await context.JenisPencemarans.FirstOrDefaultAsync(j => j.JenisID == jenis.JenisID);
            jns.NamaJenis = jenis.NamaJenis.Trim();

            context.Update(jns);
        }

        await context.SaveChangesAsync();
    }
}
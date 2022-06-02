using Silika.Entity;
using Silika.Data;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class JenisWrService : IJenisWrRepo {
    private AppDbContext context;

    public JenisWrService(AppDbContext ctx) => context = ctx;

    public IQueryable<JenisWr> JenisWrs => context.JenisWrs;

    #nullable disable
    public async Task SaveDataAsync(JenisWr jenisWr) {
        if (jenisWr.JenisID == 0) {
            await context.AddAsync(jenisWr);
        } else {
            JenisWr jns = await context.JenisWrs.FirstOrDefaultAsync(j => j.JenisID == jenisWr.JenisID);
            jns.NamaJenis = jenisWr.NamaJenis.Trim();
            jns.NoRekening = jenisWr.NoRekening.Trim();

            context.Update(jns);
        }

        await context.SaveChangesAsync();
    }
}
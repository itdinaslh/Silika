using Silika.Entity;
using Silika.Data;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class JenisKendaraanService : IJenisKendaraanRepo {
    private AppDbContext context;

    public JenisKendaraanService(AppDbContext ctx) => context = ctx;

    public IQueryable<JenisKendaraan> JenisKendaraans => context.JenisKendaraans;

    
    public async Task SaveDataAsync(JenisKendaraan jenis) {
        if (jenis.JenisID == 0) {
            await context.AddAsync(jenis);
        } else {
            JenisKendaraan? jns = await context.JenisKendaraans.FirstOrDefaultAsync(j => j.JenisID == jenis.JenisID);
            jns.KodeJenis = jenis.KodeJenis;
            jns.NamaJenis = jenis.NamaJenis;
            jns.UpdatedAt = DateTime.Now;

            context.Update(jns);
        }

        await context.SaveChangesAsync();
    }
}
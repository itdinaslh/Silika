using Silika.Entity;
using Silika.Data;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class NilaiPencemaranService : INilaiPencemaranRepo {
    private AppDbContext context;

    public NilaiPencemaranService(AppDbContext ctx) => context = ctx;

    public IQueryable<NilaiPencemaran> NilaiPencemarans => context.NilaiPencemarans;

    #nullable disable
    public async Task SaveDataAsync(NilaiPencemaran nilai) {
        if (nilai.NilaiID == 0) {
            await context.AddAsync(nilai);
        } else {
            NilaiPencemaran n = await context.NilaiPencemarans.FirstOrDefaultAsync(n => n.NilaiID == nilai.NilaiID);
            n.NamaNilai = nilai.NamaNilai;
            n.Awal = nilai.Awal;
            n.Akhir = n.Akhir;
            n.UpdatedAt = DateTime.Now;

            context.Update(n);
        }

        await context.SaveChangesAsync();
    }
}
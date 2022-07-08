using Silika.Data;
using Silika.Entity;
using Silika.Repository;

namespace Silika.Services;

public class TipeKendaraanService : ITipeKendaraan
{
    private readonly AppDbContext context;

    public TipeKendaraanService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<TipeKendaraan> TipeKendaraans => context.TipeKendaraans;

#nullable disable

    public async Task SaveDataAsync(TipeKendaraan tipe)
    {
        if (tipe.TipeKendaraanId == 0)
        {
            await context.AddAsync(tipe);
        } else
        {
            TipeKendaraan data = await context.TipeKendaraans.FindAsync(tipe.TipeKendaraanId);
            data.MerkKendaraanId = tipe.MerkKendaraanId;
            data.NamaTipe = tipe.NamaTipe;
            data.UpdatedAt = DateTime.Now;

            context.Update(data);
        }

        await context.SaveChangesAsync();
    }
}

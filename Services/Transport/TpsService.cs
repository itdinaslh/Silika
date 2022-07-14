using Silika.Data;
using Silika.Entity;
using Silika.Repository;

namespace Silika.Services;

public class TpsService : ITps
{
    private readonly AppDbContext context;

    public TpsService(AppDbContext context)
    {
        this.context = context;        
    }

    public IQueryable<Tps> Tps => context.Tps;

    public async Task SaveDataAsync(Tps tps)
    {
        if (tps.TpsId == 0)
        {
            await context.AddAsync(tps);
        } else
        {
            Tps? data = await context.Tps.FindAsync(tps.TpsId);

            if (data is not null)
            {
                data.NamaTps = tps.NamaTps;
                data.TpsCode = tps.TpsCode;
                data.KelurahanID = tps.KelurahanID;
                data.KodePos = tps.KodePos;
                data.Keterangan = tps.Keterangan;
                data.Latitude = tps.Latitude;
                data.Longitude = tps.Longitude;
                data.Alamat = tps.Alamat;
                data.StatusLahanId = tps.StatusLahanId;
                data.UpdatedAt = tps.UpdatedAt;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}

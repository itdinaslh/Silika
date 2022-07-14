using Silika.Entity;
using Silika.Repository;
using Silika.Data;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class StatusLahanService : IStatusLahan
{
    private readonly AppDbContext context;

    public StatusLahanService(AppDbContext ctx) => context = ctx; 

    public IQueryable<StatusLahan> StatusLahans => context.StatusLahans;

    public async Task SaveDataAsync(StatusLahan status)
    {
        if (status.StatusLahanId == 0)
        {
            await context.AddAsync(status);
        } else
        {
            StatusLahan? data = await context.StatusLahans.FindAsync(status.StatusLahanId);

            if (data is not null)
            {
                data.NamaStatus = status.NamaStatus;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}

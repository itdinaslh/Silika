using Silika.Repository;
using Silika.Data;
using Silika.Entity;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class PenugasanService : IPenugasan
{
    private readonly AppDbContext context;

    public PenugasanService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Penugasan> Penugasans => context.Penugasans;

    public async Task SaveDataAsync(Penugasan tugas)
    {
        if (tugas.PenugasanId == 0)
        {
            await context.AddAsync(tugas);
        } else
        {
            Penugasan? data = await context.Penugasans.FindAsync(tugas.PenugasanId);

            if (data is not null)
            {
                data.NamaPenugasan = tugas.NamaPenugasan;
                data.IsActive = tugas.IsActive;

                context.Update(data);
            }            
        }

        await context.SaveChangesAsync();
    }
}
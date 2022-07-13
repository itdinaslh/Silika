using Silika.Entity;
using Silika.Repository;
using Silika.Data;
using Microsoft.EntityFrameworkCore;

namespace Silika.Services;

public class PegawaiService : IPegawai
{
    private readonly AppDbContext context;

    public PegawaiService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Pegawai> Pegawais => context.Pegawais;

    public async Task SaveDataAsync(Pegawai peg)
    {
        if (peg.PegawaiId == 0)
        {
            await context.AddAsync(peg);
        } else
        {
            Pegawai? data = await context.Pegawais.FindAsync(peg.PegawaiId);

            if (data is not null)
            {
                data.NamaPegawai = peg.NamaPegawai;
                data.NIK = peg.NIK;                
                data.TglLahir = peg.TglLahir;
                data.NoHP = peg.NoHP;
                data.Email = peg.Email;
                data.TipePegawaiId = peg.TipePegawaiId;
                data.StatusAktif = peg.StatusAktif;
                data.TahunMasuk = peg.TahunMasuk;
                data.Catatan = peg.Catatan;
                data.BidangId = peg.BidangId;
                data.KabupatenId = peg.KabupatenId;
                data.KecamatanId = peg.KecamatanId;
                data.KelurahanId = peg.KelurahanId;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}

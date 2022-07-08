using Microsoft.EntityFrameworkCore;
using Silika.Repository;
using Silika.Data;
using Silika.Entity;

namespace Silika.Services;

public class KendaraanService : IKendaraan
{
    private readonly AppDbContext context;

    public KendaraanService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Kendaraan> Kendaraans => context.Kendaraans;

    public async Task SaveDataAsync(Kendaraan kendaraan)
    {
        if (kendaraan.KendaraanId == 0)
        {
            await context.AddAsync(kendaraan);
        } else
        {
            Kendaraan? data = await context.Kendaraans.FindAsync(kendaraan.KendaraanId);

            if (data is not null)
            {
                data.NoPolisi = kendaraan.NoPolisi;
                data.NoPintu = kendaraan.NoPintu;
                data.NoRangka = kendaraan.NoRangka;
                data.Fungsi = kendaraan.Fungsi;
                data.MerkKendaraanId = kendaraan.MerkKendaraanId;
                data.JenisKendaraanId = kendaraan.JenisKendaraanId;
                data.TipeKendaraanId = kendaraan.TipeKendaraanId;
                data.BidangAsalId = kendaraan.BidangAsalId;
                data.KabupatenAsalId = kendaraan.KabupatenAsalId;
                data.KecamatanAsalId = kendaraan.KecamatanAsalId;
                data.BidangPenugasanId = kendaraan.BidangPenugasanId;
                data.KabupatenPenugasanId = kendaraan.KabupatenPenugasanId;
                data.KecamatanPenugasanId = kendaraan.KecamatanPenugasanId;
                data.TahunPengadaan = kendaraan.TahunPengadaan;
                data.KonsumsiBBM = kendaraan.KonsumsiBBM;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}

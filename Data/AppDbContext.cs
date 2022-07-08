using Microsoft.EntityFrameworkCore;
using Silika.Entity;

namespace Silika.Data;

public class AppDbContext : DbContext {
    #nullable disable
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<JenisWr> JenisWrs { get; set; }
    public DbSet<JenisKendaraan> JenisKendaraans { get; set; }
    public DbSet<JenisTps> JenisTps { get; set; }
    public DbSet<JenisPencemaran> JenisPencemarans { get; set; }
    public DbSet<NilaiPencemaran> NilaiPencemarans { get; set; }
    public DbSet<MerkKendaraan> MerkKendaraans { get; set; }
    public DbSet<TipeKendaraan> TipeKendaraans { get; set; }

    public DbSet<Kendaraan> Kendaraans { get; set; }

    public DbSet<Pegawai> Pegawais { get; set; }


    // Wilayah
    public DbSet<Provinsi> Provinsis { get; set; }
    public DbSet<Kabupaten> Kabupatens { get; set; }
    public DbSet<Kecamatan> Kecamatans { get; set; }
    public DbSet<Kelurahan> Kelurahans { get; set; }
    public DbSet<Bidang> Bidangs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Kendaraan>()
            .HasOne(k => k.JenisKendaraan)
            .WithMany(j => j.Kendaraans)
            .HasForeignKey(k => k.JenisKendaraanId);

        builder.Entity<Kendaraan>()
            .HasOne(k => k.MerkKendaraan)
            .WithMany(m => m.Kendaraans)
            .HasForeignKey(k => k.MerkKendaraanId);

        builder.Entity<Kendaraan>()
            .HasOne(k => k.TipeKendaraan)
            .WithMany(t => t.Kendaraans)
            .HasForeignKey(k => k.TipeKendaraanId);

        builder.Entity<Kendaraan>()
            .HasOne(k => k.BidangAsal)
            .WithMany(b => b.KendaraanAsal)
            .HasForeignKey(k => k.BidangAsalId).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Kendaraan>()
            .HasOne(k => k.KabupatenAsal)
            .WithMany(kab => kab.KendaraanAsal)
            .HasForeignKey(k => k.KabupatenAsalId).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Kendaraan>()
            .HasOne(k => k.KecamatanAsal)
            .WithMany(kec => kec.KendaraanAsal)
            .HasForeignKey(k => k.KecamatanAsalId).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Kendaraan>()
            .HasOne(k => k.BidangPenugasan)
            .WithMany(b => b.KendaraanPenugasan)
            .HasForeignKey(k => k.BidangPenugasanId).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Kendaraan>()
            .HasOne(k => k.KabupatenPenugasan)
            .WithMany(kab => kab.KendaraanPenugasan)
            .HasForeignKey(k => k.KabupatenPenugasanId).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Kendaraan>()
            .HasOne(k => k.KecamatanPenugasan)
            .WithMany(kec => kec.KendaraanPenugasan)
            .HasForeignKey(k => k.KecamatanPenugasanId).OnDelete(DeleteBehavior.Restrict);
    }
}
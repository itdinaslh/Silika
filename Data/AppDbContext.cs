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
}
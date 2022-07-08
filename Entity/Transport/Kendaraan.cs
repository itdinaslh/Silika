using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("Kendaraan")]
public class Kendaraan
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KendaraanId { get; set; }

#nullable disable

    [MaxLength(25)]
    public string NoPintu { get; set; }

    [Required(ErrorMessage = "No Polisi Wajib Diisi")]
    [MaxLength(25)]
    public string NoPolisi { get; set; }

#nullable enable

    public int? MerkKendaraanId { get; set; }

    public int? TipeKendaraanId { get; set; }

    public int JenisKendaraanId { get; set; }

    public Int16? Fungsi { get; set; }

    public Guid? BidangAsalId { get; set; }

    [MaxLength(10)]
    public string? KabupatenAsalId { get; set; }

    [MaxLength(10)]
    public string? KecamatanAsalId { get; set; }

    public Guid? BidangPenugasanId { get; set; }

    [MaxLength(10)]
    public string? KabupatenPenugasanId { get; set; }

    [MaxLength(10)]
    public string? KecamatanPenugasanId { get; set; }

    [MaxLength(5)]
    public string? TahunPengadaan { get; set; }

    [MaxLength(50)]
    public string? NoRangka { get; set; }

    public Double? KonsumsiBBM { get; set; }

    public MerkKendaraan? MerkKendaraan { get; set; }

    public TipeKendaraan? TipeKendaraan { get; set; }

#nullable disable
    public JenisKendaraan JenisKendaraan { get; set; }

#nullable enable
    public Bidang? BidangAsal { get; set; }

    public Kabupaten? KabupatenAsal { get; set; }

    public Kecamatan? KecamatanAsal { get; set; }

    public Bidang? BidangPenugasan { get; set; }

    public Kabupaten? KabupatenPenugasan { get; set; }

    public Kecamatan? KecamatanPenugasan { get; set; }

    public bool? IsDeleted { get; set; } = false;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

}

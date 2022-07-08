using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

public class Pegawai
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PegawaiId { get; set; }

#nullable disable

    [Required(ErrorMessage = "Nama Pegawai Wajib Diisi")]
    [MaxLength(100)]
    public string NamaPegawai { get; set; }

    [Required(ErrorMessage = "NIK Wajib Diisi")]
    [MinLength(16)]
    [MaxLength(16)]
    public string NIK { get; set; }

    [Required(ErrorMessage = "Tanggal Lahir Wajib Diisi")]
    public DateOnly TglLahir { get; set; }

    [Required(ErrorMessage = "No HP Wajib Diisi")]
    [MaxLength(16)]
    public string NoHP { get; set; }

#nullable enable

    [MaxLength(150)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Tipe Pegawai Wajib Diisi")]
    public int TipePegawai { get; set; }

    [Required(ErrorMessage = "Status Aktif Wajib Dipilih")]
    public bool StatusAktif { get; set; }

    public Int16? TahunMasuk { get; set; }

    public string? Catatan { get; set; }

    public Guid? BidangId { get; set; }

    public string? KabupatenId { get; set; }

    public string? KecamatanId { get; set; }

    public string? KelurahanId { get; set; }

    public Bidang? Bidang { get; set; }

    [MaxLength(10)]
    public Kabupaten? Kabupaten { get; set; }

    [MaxLength(10)]
    public Kecamatan? Kecamatan { get; set; }

    [MaxLength(15)]
    public Kelurahan? Kelurahan { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("Tps")]
public class Tps
{
    public int TpsId { get; set; }

    [MaxLength(50)]
    public string? TpsCode { get; set; }

#nullable disable
    [Required(ErrorMessage = "Nama TPS Wajib Diisi..")]
    [MaxLength(150)]
    public string NamaTps { get; set; }

    public int JenisTpsId { get; set; }

    [MaxLength(15)]
    [Required(ErrorMessage = "Kelurahan Wajib Dipilih..")]
    public string KelurahanID { get; set; }

#nullable enable
    [MaxLength(10)]
    public string? KodePos { get; set; }

    public string? Keterangan { get; set; }

    [MaxLength(50)]
    public string? Latitude { get; set; }

    [MaxLength(50)]
    public string? Longitude { get; set; }

#nullable disable
    [Required(ErrorMessage = "Alamat Wajib Diisi...")]
    public string Alamat { get; set; }

    public int StatusLahanId { get; set; }

    public Kelurahan Kelurahan { get; set; }

    public StatusLahan StatusLahan { get; set; }

    public JenisTps JenisTps { get; set; }

    public bool? IsDeleted { get; set; } = false;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
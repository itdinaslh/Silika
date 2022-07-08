using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("TipeKendaraan")]
public class TipeKendaraan
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TipeKendaraanId { get; set; }

    public int? MerkKendaraanId { get; set; }

#nullable disable

    [Required(ErrorMessage = "Nama Tipe Kendaraan Wajib Diisi")]
    [MaxLength(100)]
    public string NamaTipe { get; set; }

#nullable enable
    public MerkKendaraan? MerkKendaraan { get; set; }

    public DateTime? CreatedAt { get; set;  } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public List<Kendaraan>? Kendaraans { get; set; }
}

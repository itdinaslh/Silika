using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("MerkKendaraan")]
public class MerkKendaraan {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MerkKendaraanId { get; set; }

    [MaxLength(20)]
    public string? KodeMerk { get; set; }

    #nullable disable
    [Required(ErrorMessage = "Nama Merk Wajib Diisi")]
    [MaxLength(50, ErrorMessage = "Max 50 Karakter")]
    public string NamaMerk { get; set; }

    public bool? IsActive { get; set; } = true;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public List<TipeKendaraan> TipeKendaraans { get; set; }

#nullable enable
    public List<Kendaraan>? Kendaraans { get; set; }

}
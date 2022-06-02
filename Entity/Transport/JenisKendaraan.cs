using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("JenisKendaraan")]
public class JenisKendaraan {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JenisID { get; set; }

    #nullable disable
    [Required(ErrorMessage = "Jenis Kendaraan Wajib Diisi")]
    [MaxLength(75, ErrorMessage = "Max 75 Karakter")]
    public string NamaJenis { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
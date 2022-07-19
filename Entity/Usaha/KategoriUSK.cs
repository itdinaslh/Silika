using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("KategoriUSK")]
public class KategoriUSK {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KategoriUSKId { get; set; }

    [MaxLength(20)]
    public string? KodeKategori { get; set; }

    #nullable disable
    [Required(ErrorMessage = "Nama Kategori Harap Diisi")]
    [MaxLength(150)]
    public string NamaKategori { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
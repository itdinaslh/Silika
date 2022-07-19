using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("LimbahB3")]
public class LimbahB3 {

    #nullable disable
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LimbahB3Id { get; set; }

    [MaxLength(10)]
    [Required(ErrorMessage = "Kode Limbah B3 Wajib Diisi")]
    public string KodeLimbah { get; set; }

    [Required(ErrorMessage = "Nama Limbah B3 Wajib Diisi")]
    [MaxLength(150)]
    public string NamaLimbah { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
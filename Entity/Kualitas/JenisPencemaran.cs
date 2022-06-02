using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("JenisPencemaran")]
public class JenisPencemaran {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JenisID { get; set; }

    #nullable disable
    [Required(ErrorMessage = "Nama Jenis Pencemaran Wajib Diisi")]
    public string NamaJenis { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
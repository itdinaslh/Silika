using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("NilaiPencemaran")]
public class NilaiPencemaran {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int NilaiID { get; set; }

    #nullable disable
    [Required(ErrorMessage = "Nama Nilai Pencemaran Wajib Diisi")]
    [MaxLength(30, ErrorMessage = "Max 30 Karakter")]
    public string NamaNilai { get; set; }

    [Required(ErrorMessage = "Nilai Awal Wajib Diisi")]    
    public Int16 Awal { get; set; }

    [Required(ErrorMessage = "Nilai AKhir Wajib Diisi")]
    public Int16 Akhir { get; set; }

    public bool? IsActive { get; set; } = true;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
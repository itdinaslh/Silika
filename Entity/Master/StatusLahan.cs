using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("StatusLahan")]
public class StatusLahan
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StatusLahanId { get; set; }

#nullable disable

    [MaxLength(100)]
    [Required(ErrorMessage = "Nama Status Lahan Wajib Diisi")]
    public string NamaStatus { get; set; }

    public bool? IsDeleted { get; set; } = false;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("StatusWR")]
public class StatusWR
{
    [Key]
    public int StatusId { get; set; }

#nullable disable

    [Required(ErrorMessage = "Nama Status Wajib Diisi")]
    public string StatusName { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

}

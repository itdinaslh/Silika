using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("Bidang")]
public class Bidang {
    [Key]
    public Guid BidangID { get; set; } = new Guid();

    #nullable disable
    [Required(ErrorMessage = "Nama Bidang Wajib Diisi")]
    [MaxLength(75)]
    public string NamaBidang { get; set; }    

    #nullable enable
    [MaxLength(75)]
    public string? KepalaBidang { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;    
    
}
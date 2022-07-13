using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity
{
    [Table("Penugasan")]
    public class Penugasan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PenugasanId { get; set; }

#nullable disable

        [Required(ErrorMessage = "Nama Penugasan Wajib Diisi")]
        [MaxLength(100)]
        public string NamaPenugasan { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

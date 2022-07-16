using System.ComponentModel.DataAnnotations;
using Silika.Entity;

namespace Silika.Models;

public class TpsViewModel {
    #nullable disable
    public Tps Tps {get; set;} = new Tps();

    [Required(ErrorMessage = "Harap Kota Dipilih")]
    public string KotaID { get; set; }

    [Required(ErrorMessage = "Harap Pilih Kecamatan")]
    public string KecamatanID { get; set; }
    
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silika.Entity;

[Table("Kecamatan")]
public class Kecamatan {
    #nullable disable
    [Key]
    [Required(ErrorMessage = "Kode Kecamatan Wajib Diisi")]
    [MaxLength(10, ErrorMessage = "Maksimal 10 Karakter")]
    public string KecamatanID { get; set; }
    

    [Required(ErrorMessage = "Nama Kecamatan Wajib Diisi")]
    [MaxLength(150, ErrorMessage = "Maksimal 150 Karakter")]
    public string NamaKecamatan { get; set; }

    #nullable enable
    [MaxLength(30, ErrorMessage = "Maksimal 30 Karakter")]
    public string? Latitude { get; set; }

    [MaxLength(30, ErrorMessage = "Maksimal 30 Karakter")]
    public string? Longitude { get; set; }

    #nullable disable
    [MaxLength(10)]
    public string KabupatenID { get; set; }

    public Kabupaten Kabupaten { get; set; }

    public List<Kelurahan> Kelurahans { get; set; }

#nullable enable
    public List<Kendaraan>? KendaraanAsal { get; set; }

    public List<Kendaraan>? KendaraanPenugasan { get; set; }

    public List<Pegawai>? Pegawais { get; set; }
}
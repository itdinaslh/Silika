using Silika.Entity;

namespace Silika.Models;

public class KendaraanVM
{
#nullable disable

    public Kendaraan Kendaraan { get; set; } = new Kendaraan();

    public bool IsSame { get; set; } = true;

    public string NamaMerk { get; set; } = string.Empty;

    public string NamaTipe { get; set; } = string.Empty;

    public string NamaJenis { get; set; } = string.Empty;

    public string BidangAsal { get; set; } = string.Empty;

    public string KabupatenAsal { get; set; } = string.Empty;

    public string KecamatanAsal { get; set; } = string.Empty;

    public string BidangTugas { get; set; } = string.Empty;

    public string KabupatenTugas { get; set; } = string.Empty;

    public string KecamatanTugas { get; set; } = string.Empty;
}

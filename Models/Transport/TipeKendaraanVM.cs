using Silika.Entity;

namespace Silika.Models
{
    public class TipeKendaraanVM
    {
        #nullable disable
        public TipeKendaraan TipeKendaraan { get; set; } = new TipeKendaraan();

        public string NamaMerk { get; set; } = String.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace PembelianServices.Model
{
    public class PembelianModel
    {
        [Key]
        public int Id { get; set; }
        public List<ProductDibeliModel> ListProductDibeli { get; set; }
        public TokoModel Toko { get; set; } 
        public double TotalPembelian {  get; set; }
        public DateTime TanggalPembelian { get; set; }
    }
}

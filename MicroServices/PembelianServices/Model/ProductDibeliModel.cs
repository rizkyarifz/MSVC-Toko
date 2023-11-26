namespace PembelianServices.Model
{
    public class ProductDibeliModel
    {
        public int Id { get; set; }
        public string NamaProduct { get; set; }
        public string KodeProduct { get; set; }
        public int JumlahDibeli { get; set; }
        public Double Harga { get; set; }
        public Double TotalHarga
        {
            get { return JumlahDibeli * Harga; }                
        }
    }
}

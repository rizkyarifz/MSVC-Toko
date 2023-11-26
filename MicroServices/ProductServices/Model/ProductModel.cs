namespace ProductServices.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public List<TokoModel> ListToko { get; set; }
        public string NamaProduct { get; set; }
        public string KodeProduct { get; set; }
        public int JumlahProduct { get; set; }
        public Double HargaSatuan { get; set; }
    }
}

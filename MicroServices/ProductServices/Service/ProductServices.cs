using ProductServices.Model;

namespace ProductServices.Service
{
    public class ProductService :IProductServices
    {
        private readonly ProductAppContext _appContext;
        public ProductService(ProductAppContext ctx) 
        { 
            _appContext = ctx;
        }

        public List<ProductModel> GetListData()
        {
            return _appContext.Product.ToList();
        }

        public ProductModel GetDetailData(int id)
        {
            return _appContext.Product.Where(x=>x.Id==id).FirstOrDefault();
        }

        public void Add(ProductModel data)
        {
            _appContext.Product.Add(data);
            _appContext.SaveChanges();
        }

        public void Edit(ProductModel data)
        {
            var exist = _appContext.Product.Where(x => x.Id == data.Id).FirstOrDefault();
            if (exist != null)
            {
                exist.NamaProduct = data.NamaProduct;
                exist.KodeProduct = data.KodeProduct;
                exist.JumlahProduct = data.JumlahProduct;
                exist.HargaSatuan = data.HargaSatuan;
                _appContext.Update(data);
                _appContext.SaveChanges();
            }            
        }

        public void Delete(int id)
        {
            var exist = _appContext.Product.Where(x => x.Id == id).FirstOrDefault();
            if (exist != null)
            {
                _appContext.Product.Remove(exist);
                _appContext.SaveChanges();
            }
        }
            
    }
}

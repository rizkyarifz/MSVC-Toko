using ProductServices.Model;

namespace ProductServices.Service
{
    public interface IProductServices
    {

        List<ProductModel> GetListData();
        ProductModel GetDetailData(int id);
        void Add(ProductModel data);
        void Edit(ProductModel data);
        void Delete(int id);
    }
}

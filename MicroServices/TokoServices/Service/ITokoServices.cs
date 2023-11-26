using TokoServices.Model;

namespace TokoServices.Service
{
    public interface ITokoServices
    {
        List<TokoModel> GetListData();
        TokoModel GetDetailData(int id);
        void Add(TokoModel toko);
        void Edit(TokoModel toko);
        void Delete(int id);

    }
}

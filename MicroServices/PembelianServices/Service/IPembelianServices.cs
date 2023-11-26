using PembelianServices.Model;

namespace PembelianServices.Service
{
    public interface IPembelianServices
    {

        List<PembelianModel> GetListData();
        PembelianModel GetDetailData(int id);        
        void Add(PembelianModel data);
        void Edit(PembelianModel data);
        void Delete(int id);
    }
}

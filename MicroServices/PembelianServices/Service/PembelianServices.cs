using PembelianServices.Model;

namespace PembelianServices.Service
{
    public class PembelianService : IPembelianServices
    {
        private readonly PembelianAppContext _appContext;
        public PembelianService(PembelianAppContext ctx) 
        { 
            _appContext = ctx;
        }

        public List<PembelianModel> GetListData()
        {
            return _appContext.Pembelian.ToList();
        }

        public PembelianModel GetDetailData(int id)
        {
            return _appContext.Pembelian.Where(x=>x.Id==id).FirstOrDefault();
        }


        public void Add(PembelianModel data)
        {
            data.TanggalPembelian = DateTime.Now;
            _appContext.Pembelian.Add(data);
            _appContext.SaveChanges();
        }

        public void Edit(PembelianModel data)
        {
            var exist = _appContext.Pembelian.Where(x => x.Id == data.Id).FirstOrDefault();
            if (exist != null)
            {
                exist.ListProductDibeli = data.ListProductDibeli;
                exist.TanggalPembelian = DateTime.Now;
                _appContext.Update(data);
                _appContext.SaveChanges();
            }            
        }

        public void Delete(int id)
        {
            var exist = _appContext.Pembelian.Where(x => x.Id == id).FirstOrDefault();
            if (exist != null)
            {
                _appContext.Pembelian.Remove(exist);
                _appContext.SaveChanges();
            }
        }
            
    }
}

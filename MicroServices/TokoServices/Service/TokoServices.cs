using TokoServices.Model;

namespace TokoServices.Service
{
    public class TokoService : ITokoServices
    {
        private readonly TokoAppContext _appContext;
        public TokoService(TokoAppContext ctx) 
        { 
            _appContext = ctx;
        }

        public List<TokoModel> GetListData()
        {
            return _appContext.Toko.ToList();
        }

        public TokoModel GetDetailData(int id)
        {
            return _appContext.Toko.Where(x=>x.Id==id).FirstOrDefault();
        }



        public void Add(TokoModel toko)
        {
            _appContext.Toko.Add(toko);
            _appContext.SaveChanges();
        }

        public void Edit(TokoModel toko)
        {
            var data = _appContext.Toko.Where(x => x.Id == toko.Id).FirstOrDefault();
            if (data != null)
            {
                data.Name = toko.Name;                
                _appContext.Update(data);
                _appContext.SaveChanges();
            }            
        }

        public void Delete(int id)
        {
            var toko = _appContext.Toko.Where(x => x.Id == id).FirstOrDefault();
            if (toko != null)
            {
                _appContext.Toko.Remove(toko);
                _appContext.SaveChanges();
            }
        }
            
    }
}

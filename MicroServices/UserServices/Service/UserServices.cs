using UserServices.Model;

namespace UserServices.Service
{
    public class UserService :IUserServices
    {
        private readonly UserAppContext _appContext;
        public UserService(UserAppContext ctx) 
        { 
            _appContext = ctx;
        }

        public List<UserModel> GetListData()
        {
            return _appContext.Users.ToList();
        }

        public UserModel GetDetailData(int id)
        {
            return _appContext.Users.Where(x=>x.Id==id).FirstOrDefault();
        }

        public void Add(UserModel data)
        {
            _appContext.Users.Add(data);
            _appContext.SaveChanges();
        }

        public void Edit(UserModel data)
        {
            var exist = _appContext.Users.Where(x => x.Id == data.Id).FirstOrDefault();
            if (exist != null)
            {
                exist.Name = data.Name;
                exist.UserRole = data.UserRole;
                _appContext.Update(data);
                _appContext.SaveChanges();
            }            
        }

        public void Delete(int id)
        {
            var exist = _appContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (exist != null)
            {
                _appContext.Users.Remove(exist);
                _appContext.SaveChanges();
            }
        }
            
    }
}

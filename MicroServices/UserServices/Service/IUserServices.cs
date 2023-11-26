using UserServices.Model;

namespace UserServices.Service
{
    public interface IUserServices
    {
        List<UserModel> GetListData();
        UserModel GetDetailData(int id);
        void Add(UserModel data);
        void Edit(UserModel data);
        void Delete(int id);
    }
}

namespace UserServices.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserRole { get; set; }
        public List<TokoModel> ListToko { get; set; }
    }
}

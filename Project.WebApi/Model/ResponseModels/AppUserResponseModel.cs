using Project.Entities.Enums;

namespace Project.WebApi.Model.ResponseModels
{
    public class AppUserResponseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DataStatus Status { get; set; }
    }
}


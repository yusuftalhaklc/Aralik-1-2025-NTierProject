using Project.Entities.Enums;

namespace Project.WebApi.Model.ResponseModels
{
    public class AppUserProfileResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DataStatus Status { get; set; }
    }
}


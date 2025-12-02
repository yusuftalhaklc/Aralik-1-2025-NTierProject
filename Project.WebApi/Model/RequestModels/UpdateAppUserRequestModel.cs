namespace Project.WebApi.Model.RequestModels
{
    public class UpdateAppUserRequestModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}


namespace Project.WebApi.Model.RequestModels
{
    public class UpdateCategoryRequestModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}

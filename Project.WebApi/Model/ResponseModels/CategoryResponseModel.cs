using Project.Entities.Enums;

namespace Project.WebApi.Model.ResponseModels
{
    public class CategoryResponseModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public DataStatus Status { get; set; }
    }
}

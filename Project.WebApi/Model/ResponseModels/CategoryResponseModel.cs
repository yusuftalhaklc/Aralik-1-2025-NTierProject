using Project.Entities.Enums;

namespace Project.WebApi.Model.RequestModels
{
    public class CategoryResponseModel
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public DataStatus status { get; set; }
    }
}

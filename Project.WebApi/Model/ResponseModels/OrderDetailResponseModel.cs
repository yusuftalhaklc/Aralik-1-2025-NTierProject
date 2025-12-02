using Project.Entities.Enums;

namespace Project.WebApi.Model.ResponseModels
{
    public class OrderDetailResponseModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public DataStatus Status { get; set; }
    }
}


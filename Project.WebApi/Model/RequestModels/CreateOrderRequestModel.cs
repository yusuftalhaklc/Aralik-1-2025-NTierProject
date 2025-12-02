namespace Project.WebApi.Model.RequestModels
{
    public class CreateOrderRequestModel
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}


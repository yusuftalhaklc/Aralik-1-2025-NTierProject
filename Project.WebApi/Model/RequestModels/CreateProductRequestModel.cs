namespace Project.WebApi.Model.RequestModels
{
    public class CreateProductRequestModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}


namespace SimpleSearch.Api.Models.Request
{
    public class OrderSearchRequest
    {
        public string CustomerName { get; set; }
        public double MinPrice { get; set; }
    }
}
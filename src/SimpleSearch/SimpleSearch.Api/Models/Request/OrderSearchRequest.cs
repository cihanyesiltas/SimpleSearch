namespace SimpleSearch.Api.Models.Request
{
    public class OrderSearchRequest : PaginationBaseRequest
    {
        public string CustomerName { get; set; }
        public double MinPrice { get; set; }
    }
}
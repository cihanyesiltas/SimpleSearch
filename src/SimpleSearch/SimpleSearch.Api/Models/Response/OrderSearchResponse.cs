namespace SimpleSearch.Api.Models.Response
{
    public class OrderSearchResponse
    {
        public string Id { get; set; }
        public string CustomerFullName { get; set; }
        public double TaxfulTotalPrice { get; set; }
        public string CustomerGender { get; set; }
    }
}
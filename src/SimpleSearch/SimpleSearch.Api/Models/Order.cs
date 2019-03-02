namespace SimpleSearch.Api.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string CustomerFullName { get; set; }
        public double TaxfulTotalPrice { get; set; }
        public string CustomerGender { get; set; }
    }
}
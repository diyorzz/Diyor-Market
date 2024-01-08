namespace DiyorMarket.Domain.ResourceParameters
{
    public class ProductResourceParameters
    {
        private const int MaxPageSize = 25;
        public int? CategoryId { get; set; }
        public string? SearchString { get; set; }
        public decimal? Price { get; set; } 
        public decimal? PriceLessThan {  get; set; }
        public decimal? PriceGraterThan { get; set; }
        public string OrderBy { get; set; } = "id";
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 15;

        public int Pagesize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}

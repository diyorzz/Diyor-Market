namespace DiyorMarket.Domain.ResourceParameters
{
    public class SupplyItemResourceParamentrs
    {
        private const int MaxPageSize = 15;
        public int? ProductId { get; set; }
        public int? SupplyId { get; set; }
        public int? QuantityLessThan { get; set; }
        public int? QuantityGreaterThan { get; set; }
        public decimal? UnitPrice { get; set; }
        public string OrderBy { get; set; } = "id";

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int Pagesize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}

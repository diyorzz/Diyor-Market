
namespace DiyorMarket.Domain.ResourceParameters
{
    public class CustomerResourceParameters
    {
        private const int MaxPageSize = 20;
        public string? SearchString { get; set; }
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

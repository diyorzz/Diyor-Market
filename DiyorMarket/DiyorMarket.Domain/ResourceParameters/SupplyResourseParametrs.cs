namespace DiyorMarket.Domain.ResourceParameters
{
    public class SupplyResourseParametrs 
    {
        private const int MaxPageSize = 15;
        public string? OrderBy { get; set; } = "id";
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int Pagesize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}

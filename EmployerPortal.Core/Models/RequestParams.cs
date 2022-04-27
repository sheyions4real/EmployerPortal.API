namespace EmployerPortal.Core.Models
{
    public class RequestParams
    {
        // use this model to control the paging from get API
        const int maxPageSize = 50;
        public int PageNumber { get; set; }
        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }

    }
}

namespace piyoz.uz.DataAccess.Entities
{
    public class PaginatedData<T>
    {
        public IList<T> Data { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int TotalCount { get; set; }
    }
}

namespace Catalog.Core.Specifications;

public class Pagination<T> where T : class
{
    public Pagination(int pageIndex, int pageSize, long count, IReadOnlyList<T> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
    }

    public Pagination() { }

    public int PageIndex { set; get; }
    public int PageSize { set; get; }
    public long Count { set; get; }
    public IReadOnlyList<T> Data { set; get; }
}
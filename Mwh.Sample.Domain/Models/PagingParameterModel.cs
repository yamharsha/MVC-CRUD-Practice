﻿
namespace Mwh.Sample.Domain.Models;
/// <summary>
/// Paging Parameter Model
/// </summary>
public class PagingParameterModel
{
    private const int maxPageSize = 5000;
    private int _pageSize { get; set; }
    public PagingParameterModel()
    {
        _pageSize = 300;
        PageNumber = 1;
    }
    public object GetMetaData(long TotalCount)
    {
        return new
        {
            totalCount = TotalCount,
            pageSize = PageSize,
            currentPage = PageNumber,
            totalPages = (int)Math.Ceiling(TotalCount / (double)PageSize),
            previousPage = PageNumber > 1 ? "Yes" : "No",
            nextPage = PageNumber < (int)Math.Ceiling(TotalCount / (double)PageSize) ? "Yes" : "No"
        };
    }

    public int PageNumber { get; set; }
    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = value > maxPageSize ? maxPageSize : value; }
    }
}

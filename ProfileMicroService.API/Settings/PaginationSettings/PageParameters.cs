namespace ProfileMicroService.API.Settings.PaginationSettings;

public class PageParameters
{
    private const int _minimumPageNumber = 1;
    private const int _minimumPageSize = 1;

    private int _pageNumber;
    public required int PageNumber 
    {
        get => _pageNumber;
        set => _pageNumber = value <= 0 ? _minimumPageNumber : value;
    }

    private int _pageSize;
    public required int PageSize 
    {
        get => _pageSize;
        set => _pageSize = value <= 0 ? _minimumPageSize : value;
    }
}

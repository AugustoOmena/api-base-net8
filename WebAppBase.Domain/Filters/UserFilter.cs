using WebAppBase.Shared.Paging;

namespace WebAppBase.Domain.Filters;

public class UserFilter : Pagination
{
    public string Name { get; set; }

    public string Email { get; set; }

    //public bool? Active { get; set; }
}
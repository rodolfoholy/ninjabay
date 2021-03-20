using NinjaBay.Shared.Paging;

namespace NinjaBay.Domain.Filters
{
    public class UserFilter : Pagination
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
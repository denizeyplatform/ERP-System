using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Common.Paginations
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public static PagedResponse<T> Create(IEnumerable<T> items, int count, int page, int pageSize)
        {
            return new PagedResponse<T>
            {
                Items = items,
                TotalCount = count,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}

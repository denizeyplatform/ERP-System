using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Common.Paginations
{
    public class PaginationParams
    {
        private const int MaxPageSize = 100;

        public int Page { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string Search { get; set; } = string.Empty;
    }
}

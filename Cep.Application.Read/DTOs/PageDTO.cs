using System.Collections.Generic;

namespace Cep.Application.Read.DTOs
{
    public class PageDTO<T>
    {
        public int? PageSize { get; set; }
        public int PageCount { get; set; }
        public int? PageNumber { get; set; }
        public int PageTotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}

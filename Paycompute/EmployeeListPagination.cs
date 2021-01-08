using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paycompute
{
    public class EmployeeListPagination<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        
        public EmployeeListPagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public bool IsPreviousPageAvaliable => PageIndex > 1;
        public bool IsNextPageAvaliable => PageIndex < TotalPages;

        public static EmployeeListPagination<T> Create(IList<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex -1) * pageSize).Take(pageSize).ToList();
            return new EmployeeListPagination<T>(items, count, pageIndex, pageSize);
        }
    }
}

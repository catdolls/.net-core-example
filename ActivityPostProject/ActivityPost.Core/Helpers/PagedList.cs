using System;
using System.Collections.Generic;
using System.Linq;

namespace ActivityPost.Services.Helpers
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            this.TotalItems = source.Count();
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.List = pageNumber != 0 && pageSize != 0 ? source
                            .Skip(pageSize * (pageNumber - 1))
                            .Take(pageSize)
                            .ToList() : source.ToList();
        }

        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public List<T> List { get; }
        public int TotalPages => this.PageNumber != 0 && this.PageSize != 0 ? (int)Math.Ceiling(this.TotalItems / (double)this.PageSize) : 0; 
        public bool HasPreviousPage => this.PageNumber > 1;
        public bool HasNextPage => this.PageNumber < this.TotalPages;
        public int NextPageNumber => this.HasNextPage ? this.PageNumber + 1 : this.TotalPages;
        public int PreviousPageNumber => this.HasPreviousPage ? this.PageNumber - 1 : 1;

        public PagingHeader GetHeader()
        {
            return new PagingHeader(this.TotalItems, this.PageNumber, this.PageSize, this.TotalPages);
        }
    }
}

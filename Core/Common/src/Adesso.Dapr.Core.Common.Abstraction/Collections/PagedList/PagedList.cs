using System;
using System.Collections.Generic;
using System.Linq;
using Adesso.Dapr.Core.Common.Abstraction.Exception;

namespace Adesso.Dapr.Core.Common.Abstraction.Collections
{
    public class PagedList<T> : IPagedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="indexFrom">The index from.</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int indexFrom, int? totalCount = null)
        {
            if (indexFrom > pageIndex)
            {
                throw new AdessoException(
                    $"IndexFrom: {indexFrom} > PageIndex: {pageIndex}, must indexFrom <= pageIndex");
            }

            if (source is IQueryable<T> querable)
            {
                this.PageIndex = pageIndex;
                this.PageSize = pageSize;
                this.IndexFrom = indexFrom;
                this.TotalCount = totalCount ?? querable.Count();
                this.TotalPages = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);

                this.Items = querable.Skip((this.PageIndex - this.IndexFrom) * this.PageSize).Take(this.PageSize)
                    .ToList();
            }
            else
            {
                this.PageIndex = pageIndex;
                this.PageSize = pageSize;
                this.IndexFrom = indexFrom;
                this.TotalCount = totalCount ?? source.Count();
                this.TotalPages = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);

                this.Items = source.Skip((this.PageIndex - this.IndexFrom) * this.PageSize).Take(this.PageSize)
                    .ToList();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}" /> class.
        /// </summary>
        public PagedList()
        {
            this.Items = Array.Empty<T>();
        }

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>The total count.</value>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        /// <value>The total pages.</value>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the index from.
        /// </summary>
        /// <value>The index from.</value>
        public int IndexFrom { get; set; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IList<T> Items { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets the has previous page.
        /// </summary>
        /// <value>The has previous page.</value>
        public bool HasPreviousPage => this.PageIndex - this.IndexFrom > 0;

        /// <summary>
        /// Gets a value indicating whether gets the has next page.
        /// </summary>
        /// <value>The has next page.</value>
        public bool HasNextPage => this.PageIndex - this.IndexFrom + 1 < this.TotalPages;
    }
}

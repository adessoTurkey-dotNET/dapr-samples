using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace Adesso.Dapr.Core.Common.Abstraction.Collections
{
    public static class Extentions
    {
        /// <summary>
        /// Creates an empty of <see cref="IPagedList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type for paging. </typeparam>
        /// <returns>An empty instance of <see cref="IPagedList{T}"/>.</returns>
        public static IPagedList<T> Empty<T>()
        {
            return new PagedList<T>();
        }

        /// <summary>
        /// Converts the specified source to <see cref="IPagedList{T}"/> by the specified <paramref name="pageIndex"/> and <paramref name="pageSize"/>.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="source">The source to paging.</param>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="indexFrom">The start index value.</param>
        /// <returns>An instance of the inherited from <see cref="IPagedList{T}"/> interface.</returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize,
            int? totalCount = null, int indexFrom = 1)
        {
            return new PagedList<T>(source, pageIndex, pageSize, indexFrom, totalCount);
        }

        /// <summary>
        /// Go to page by page
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="source">The source</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>Each page of source</returns>
        public static IEnumerable<IEnumerable<T>> ToPagedList<T>(this IEnumerable<T> source, int pageSize)
        {
            Contract.Requires(source != null);
            Contract.Requires(pageSize > 0);
            Contract.Ensures(Contract.Result<IEnumerable<IEnumerable<T>>>() != null);

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var currentPage = new List<T>(pageSize)
                    {
                        enumerator.Current,
                    };

                    while (currentPage.Count < pageSize && enumerator.MoveNext())
                    {
                        currentPage.Add(enumerator.Current);
                    }

                    yield return new ReadOnlyCollection<T>(currentPage);
                }
            }
        }
    }
}

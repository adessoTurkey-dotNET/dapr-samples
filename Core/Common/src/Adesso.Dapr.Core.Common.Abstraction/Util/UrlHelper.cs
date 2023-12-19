using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Adesso.Dapr.Core.Common.Abstraction.Util
{
    public static class UrlHelper
    {
        public static string UrlGenerator(string urlBaseAddress, Dictionary<string, string> queryParams = null, List<string> urlSegments = null,bool paramsWithoutEncoding = false)
        {
            var urlSections = new StringBuilder();

            if (urlSegments != null)
            {
                foreach (var segment in urlSegments)
                {
                    urlSections.Append(segment);
                    if (!segment.EndsWith("/"))
                    {
                        urlSections.Append('/');
                    }
                }
            }

            if (queryParams != null)
            {
                urlSections.Append('?');

                foreach (var item in queryParams)
                {
                    var queryParam = paramsWithoutEncoding ? item.Value : HttpUtility.UrlEncode(item.Value);
                    urlSections.Append($"{item.Key}={queryParam}");

                    if (item.Key != queryParams.Last().Key)
                    {
                        urlSections.Append('&');
                    }
                }
            }

            if (!urlBaseAddress.EndsWith("/"))
            {
                urlBaseAddress += "/";
            }

            var url = urlBaseAddress + urlSections.ToString();

            return url;

        }
    }
}

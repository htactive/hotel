using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Helpers
{
    public class SlugOrIdHelper
    {
        public static string EncodeSlugOrId(string slug, int id)
        {
            return System.Net.WebUtility.UrlEncode(!string.IsNullOrEmpty(slug) ? slug : id.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace BookCollectionMain
{
    public static class BookCollectionClass
    {
        public static HttpClient Client = new HttpClient();
        static BookCollectionClass()
        {
            Client.BaseAddress = new Uri("http://localhost:53456/api/");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
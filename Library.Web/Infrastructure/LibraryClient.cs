using System;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Library.Web.Infrastructure
{
    public class LibraryClient : RestClient
    {
        public LibraryClient(IConfiguration configuration)
        {
            var uri = new Uri(configuration.GetSection("Api").GetValue<string>("Library"));

            this.BaseUrl = uri;
        }
    }
}
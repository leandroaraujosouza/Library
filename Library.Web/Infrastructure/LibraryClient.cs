using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Library.Web.Infrastructure
{
    public class LibraryClient : RestClient
    {
        public LibraryClient(IConfiguration configuration)
        {
            var uri = new Uri(configuration.GetSection("Api").GetValue<string>("Library"));

            this.BaseUrl = uri;
            var jsonSettigs = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            this.UseNewtonsoftJson(jsonSettigs);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Client.Models;
using Library.Web.Infrastructure;
using RestSharp;

namespace Library.Web.Services
{
    public class BooksService
    {
        private readonly LibraryClient libraryClient;

        public BooksService(LibraryClient libraryClient)
        {
            this.libraryClient = libraryClient;
        }

        public async Task<object> Add(BookToCreate bookToCreate)
        {
            var request = new RestRequest("/api/books") { Method = Method.POST, RequestFormat = DataFormat.Json };

            request.AddJsonBody(bookToCreate);

            var result = await libraryClient.ExecutePostAsync<BookToReturn>(request);

            return result.Data;
        }

        public async Task<List<object>> GetAll()
        {
            var request = new RestRequest("/api/books") { Method = Method.GET, RequestFormat = DataFormat.Json };
            var result = await libraryClient.ExecuteGetAsync<List<object>>(request);

            return result.Data;
        }
    }
}
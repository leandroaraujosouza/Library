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

        public async Task<object> Edit(string id, BookToEdit bookToEdit)
        {
            var request = new RestRequest($"/api/books/{id}") { Method = Method.PUT, RequestFormat = DataFormat.Json };
            request.AddJsonBody(bookToEdit);

            var result = await libraryClient.PutAsync<BookToReturn>(request);

            return result;
        }

        public async Task<List<object>> GetAll()
        {
            var request = new RestRequest("/api/books") { Method = Method.GET, RequestFormat = DataFormat.Json };
            var result = await libraryClient.ExecuteGetAsync<List<object>>(request);

            return result.Data;
        }

        public async Task<object> Get(string id)
        {
            var request = new RestRequest($"/api/books/{id}") { Method = Method.GET, RequestFormat = DataFormat.Json };
            var result = await libraryClient.ExecuteGetAsync<object>(request);

            return result.Data;
        }

        public async Task<object> Delete(string id)
        {
            var request = new RestRequest($"/api/books/{id}") { Method = Method.DELETE, RequestFormat = DataFormat.Json };

            var result = await libraryClient.DeleteAsync<object>(request);

            return result;
        }
    }
}
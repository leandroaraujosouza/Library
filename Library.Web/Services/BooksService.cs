using System.Threading.Tasks;
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

        public async Task<object> Add(object BookToAdd)
        {
            var request = new RestRequest("/api/Books") { Method = Method.POST, RequestFormat = DataFormat.Json };

            request.AddJsonBody(BookToAdd);

            var result = await libraryClient.ExecutePostAsync<object>(request);

            return result.Data;
        }
    }
}
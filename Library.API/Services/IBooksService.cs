using Library.API.Entities;
using Library.API.Models;
using System.Collections.Generic;

namespace Library.API.Services
{
    public interface IBooksService
    {
        Book Add(BookToCreate bookToCreate);
        Book Delete(string id);
        BookToReturn Edit(string id, BookToEdit bookToEdit);
        IEnumerable<BookToReturn> Get();
        Book GetById(string id);
    }
}
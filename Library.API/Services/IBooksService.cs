﻿using Library.API.Entities;
using Library.Client.Models;
using System.Collections.Generic;

namespace Library.API.Services
{
    public interface IBooksService
    {
        Book Add(BookToCreate bookToCreate);
        Book Delete(string id);
        BookToReturn Edit(string id, BookToEdit bookToEdit);
        IEnumerable<BookToReturn> GetAll();
        Book GetById(string id);
    }
}
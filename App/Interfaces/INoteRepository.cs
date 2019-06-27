using System;
using System.Collections.Generic;
using App.Entities;

namespace App.Interfaces
{
    public interface INoteRepository
    {
        List<Note> FindByUser(User user);

        void Add(Note note);

        void Update(int id, string content, DateTime updated);

        void Delete(int id);
    }
}
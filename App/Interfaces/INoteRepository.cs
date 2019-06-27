using System;
using System.Collections.Generic;
using App.Entities;

namespace App.Interfaces
{
    public interface INoteRepository
    {
        IList<Note> FindByUser(User user);
        
        void Add(Note note);
        
        Note FindById(int id);

        void Update(Note note);

        void Delete(Note note);
    }
}
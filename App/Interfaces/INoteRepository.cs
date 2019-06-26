using System;
using System.Collections.Generic;
using App.Entities;

namespace App.Interfaces
{
    public interface INoteRepository
    {
        List<Note> FindByUser(User user);

        Note FindById(int id);
        
        int Add(Note note);

        void Update(Note note);

        void Delete(Note note);
    }
}
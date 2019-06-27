using System;
using System.Collections.Generic;
using App.Entities;

namespace App.Interfaces
{
    public interface INoteService
    {
        List<Note> GetAllByUser(User user);
        Note FindById(int id);
        void Create(Note note);
        void Update(Note note);
        void Delete(Note note);
    }
}
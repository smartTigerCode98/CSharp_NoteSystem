
using System.Collections.Generic;
using App.Entities;

namespace App.Interfaces
{
    public interface INoteRepository
    {
        IList<Note> FindByUser(User user);
      
        Note FindById(int id);
        
        void Add(Note note);

        void Update(Note note);

        void Delete(Note note);
    }
}
using System;
using System.Collections.Generic;
using App.Entities;

namespace App.Interfaces
{
    public interface INoteService
    {
        List<Note> GetAllByUser(User user);
        void Create(User user, string content, DateTime created);
        void Update(int id, string content, DateTime updated);
        void Delete(int id);
    }
}
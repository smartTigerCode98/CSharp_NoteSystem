using System;
using System.Collections.Generic;
using System.Linq;
using App.Entities;
using App.Interfaces;

namespace App.Repositories
{
    public class LocalNoteRepository : INoteRepository
    {
        private readonly List<Note> _notes;
        private int _nextId;
        private int NextId => _nextId++;

        public LocalNoteRepository()
        {
            _notes = new List<Note>();
        }
        
        public List<Note> FindByUser(User user)
        {
            return _notes.FindAll(n => n.Owner == user);
        }

        public int Add(Note note)
        {
            _nextId = NextId;
            _notes.Add(note);
            return _nextId;
        }

        public void Update(int id, string content, DateTime updated)
        {
            _notes.Where(n => n.Id == id).Select(u => 
                { 
                    u.Content = content;
                    u.Created = updated;
                    return u;
                }).ToList();
        }

        public void Delete(int id)
        {
            _notes.RemoveAll(n => n.Id == id);
        }
    }
}
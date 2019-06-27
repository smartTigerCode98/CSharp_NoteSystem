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
        
        public IList<Note> FindByUser(User user)
        {
            return _notes.FindAll(n => n.Owner == user).ToList();
        }
        
        public Note FindById(int id)
        {
            return _notes.FirstOrDefault(n => n.Id == id);
        }

        public void Add(Note note)
        {
            note.Id = NextId;
            _notes.Add(note);
        }

        public void Update(Note note)
        {
            var necessaryNote = _notes.First(n => n.Id == note.Id);
            necessaryNote.Content = note.Content;
            necessaryNote.Created = note.Created;
        }

        public void Delete(Note note)
        {
            _notes.RemoveAll(n => n.Id == note.Id);
        }
    }
}
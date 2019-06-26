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

        public Note FindById(int id)
        {
            return _notes.FirstOrDefault(n => n.Id == id);
        }

        public int Add(Note note)
        {
            _nextId = NextId;
            _notes.Add(note);
            return _nextId;
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
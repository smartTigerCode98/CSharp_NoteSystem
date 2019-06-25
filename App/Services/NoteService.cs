using System;
using System.Collections.Generic;
using App.Entities;
using App.Interfaces;

namespace App.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        
        public List<Note> GetAllByUser(User user)
        {
            return _noteRepository.FindByUser(user);
        }

        public void Create(User user, string content, DateTime created)
        {
            _noteRepository.Add(new Note(user, content, created));
        }

        public void Update(int id, string content, DateTime updated)
        {
            _noteRepository.Update(id, content, updated);
        }

        public void Delete(int id)
        {
            _noteRepository.Delete(id);
        }
    }
}
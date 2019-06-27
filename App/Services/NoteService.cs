using System;
using System.Collections.Generic;
using System.Linq;
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
            return _noteRepository.FindByUser(user).ToList();
        }

        public Note FindById(int id)
        {
            return _noteRepository.FindById(id);
        }

        public void Create(Note note)
        {
            _noteRepository.Add(note);
        }

        public void Update(Note note)
        {
            _noteRepository.Update(note);
        }

        public void Delete(Note note)
        {
            _noteRepository.Delete(note);
        }
    }
}
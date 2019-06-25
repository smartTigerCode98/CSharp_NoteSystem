using System;
using System.Collections.Generic;
using App.Entities;
using App.Interfaces;

namespace App.Controllers
{
    public class NoteController : INoteController
    {
        private readonly INoteService _noteService;
        
        public User User { get; set; }
        
        private readonly List<string> _commands = new List<string>{"show", "create", "update", "delete"};

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        
        public void Run()
        {
            while (true)
            {
                var command = RequestPrompt("Available commands[show, create, update, delete]");
                if (!_commands.Contains(command))
                {
                    Console.WriteLine("Invalid command. Please try again");
                    continue;
                }

                switch (command)
                {
                    case "show":
                    {
                        ShowAll();
                        break;
                    }

                    case "create":
                    {
                        Create();
                        break;
                    }

                    case "update":
                    {
                        Update();
                        break;
                    }

                    case "delete":
                    {
                        Delete();
                        break;
                    }
                }
            }
        }
        
        public void ShowAll()
        {
            var notes = _noteService.GetAllByUser(User);
            foreach (var note in notes)
            {
                Console.WriteLine("");
                Console.WriteLine($"Id note is {note.Id}");
                Console.WriteLine($"Content: {note.Content}");
                Console.WriteLine($"Date last modified: {note.Created}");
                Console.WriteLine("");
            }
        }

        public void Create()
        {
            var content = RequestPrompt("Input you message");
            _noteService.Create(User, content, DateTime.Now);
        }

        public void Update()
        {
            var idList = GetAllIdForUserNotes();
            var idListString = string.Join(",", idList.ToArray());
            var givenId = -1;
            while (!idList.Contains(givenId) && idList.Count > 0)
            {
                int.TryParse(RequestPrompt($"Input id for note that will be updated. Available id: {idListString}"),
                    out givenId);
            }

            var newContent = RequestPrompt("Input new content:");
            _noteService.Update(givenId, newContent, DateTime.Now);
        }

        public void Delete()
        {
            var idList = GetAllIdForUserNotes();
            var idListString = string.Join(",", idList.ToArray());
            var givenId = -1;
            while (!idList.Contains(givenId) && idList.Count > 0)
            {
                int.TryParse(RequestPrompt($"Input id for note that will be updated. Available id: {idListString}"),
                    out givenId);
                
            }
            _noteService.Delete(givenId);
        }
        
        private static string RequestPrompt(string prompt)
        {
            Console.WriteLine($"{prompt}");
            return Console.ReadLine();
        }

        private List<int> GetAllIdForUserNotes()
        {
            var idList = new List<int>();
            var notes = _noteService.GetAllByUser(User);
            foreach (var note in notes)
            {
                idList.Add(note.Id);
            }

            return idList;
        }
    }
}
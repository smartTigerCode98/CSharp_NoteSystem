using System;
using System.Collections.Generic;
using App.Enum;
using App.Entities;
using App.Interfaces;

namespace App.Controllers
{
    public class NoteController
    {
        private readonly INoteService _noteService;
        private readonly IGuardService _guardService;
        
        private readonly List<string> _commands = new List<string>
        {
            NoteCommands.Create, NoteCommands.Show,
            NoteCommands.Update, NoteCommands.Delete
        };

        public NoteController(INoteService noteService, IGuardService guardService)
        {
            _noteService = noteService;
            _guardService = guardService;
        }
        
        public void Run()
        {
            var commandsListString = string.Join(",", _commands.ToArray());

            while (true)
            {
                var command = RequestPrompt($"Available commands[{commandsListString}]");
                if (!_commands.Contains(command))
                {
                    Console.WriteLine("Invalid command. Please try again");
                    continue;
                }

                switch (command)
                {
                    case NoteCommands.Show:
                    {
                        ShowAll();
                        break;
                    }

                    case NoteCommands.Create:
                    {
                        Create();
                        break;
                    }

                    case NoteCommands.Update:
                    {
                        Update();
                        break;
                    }

                    case NoteCommands.Delete:
                    {
                        Delete();
                        break;
                    }
                }
            }
        }

        private void ShowAll()
        {
            var notes = _noteService.GetAllByUser(_guardService.User);
            foreach (var note in notes)
            {
                Console.WriteLine("");
                Console.WriteLine($"Id note is {note.Id}");
                Console.WriteLine($"Content: {note.Content}");
                Console.WriteLine($"Date last modified: {note.Created}");
                Console.WriteLine("");
            }
        }

        private void Create()
        {
            var content = RequestPrompt("Input you message");
            _noteService.Create(new Note(_guardService.User, content, DateTime.Now));
        }

        private void Update()
        {
            var idList = GetAllIdForUserNotes();
            var idListString = string.Join(",", idList.ToArray());
            var givenId = -1;
            while (!idList.Contains(givenId) && idList.Count > 0)
            {
                if (!int.TryParse(RequestPrompt($"Input id for note that will be updated. Available id: {idListString}"),
                    out givenId))
                {
                    givenId = -1;
                }
            }

            var newContent = RequestPrompt("Input new content:");
            var note = _noteService.FindById(givenId);
            note.Content = newContent;
            note.Created = DateTime.Now;
            _noteService.Update(note);
        }

        private void Delete()
        {
            var idList = GetAllIdForUserNotes();
            var idListString = string.Join(",", idList.ToArray());
            var givenId = -1;
            while (!idList.Contains(givenId) && idList.Count > 0)
            {
                if (!int.TryParse(RequestPrompt($"Input id for note that will be updated. Available id: {idListString}"),
                    out givenId))
                {
                    givenId = -1;
                }
                
            }
            _noteService.Delete(_noteService.FindById(givenId));
        }
        
        private static string RequestPrompt(string prompt)
        {
            Console.WriteLine($"{prompt}");
            return Console.ReadLine();
        }

        private List<int> GetAllIdForUserNotes()
        {
            var idList = new List<int>();
            var notes = _noteService.GetAllByUser(_guardService.User);
            foreach (var note in notes)
            {
                idList.Add(note.Id);
            }

            return idList;
        }
    }
}
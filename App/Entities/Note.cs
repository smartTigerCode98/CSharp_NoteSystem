using System;

namespace App.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public User Owner { get; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public Note(User owner, string content, DateTime created)
        {
            Owner = owner;
            Content = content;
            Created = created;
        }
    }
}
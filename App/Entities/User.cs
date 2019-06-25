namespace App.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Email { get; }
        public string PasswordHash { get; }

        public User(string name, string email, string passwordHash)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }

        public bool Equals(User user)
        {
            if (user == null)
            {
                return false;
            }

            return Id == user.Id && Name == user.Name && Email == user.Email && PasswordHash == user.PasswordHash;
        }
    }
}
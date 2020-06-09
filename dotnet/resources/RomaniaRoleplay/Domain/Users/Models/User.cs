using System;

namespace Domain.Users.Models
{
    public class User : IEquatable<User>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastActiveDate { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return other != null &&
                   Id == other.Id &&
                   Username == other.Username &&
                   Password == other.Password &&
                   Email == other.Email &&
                   RegisterDate == other.RegisterDate &&
                   LastActiveDate == other.LastActiveDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Username, Password, Email, RegisterDate, LastActiveDate);
        }
    }
}

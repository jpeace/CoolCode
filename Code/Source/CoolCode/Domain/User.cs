namespace CoolCode.Domain
{
    public class User
    {
        public virtual int UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual UserProfile Profile { get; set; }
    }

    public class UserProfile
    {
        public virtual int UserProfileId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Company { get; set; }

        public virtual User User { get; set; }
    }
}
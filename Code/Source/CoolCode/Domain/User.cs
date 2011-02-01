namespace CoolCode.Domain
{
    public class User
    {
        public virtual int UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}
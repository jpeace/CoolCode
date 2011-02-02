namespace CoolCode.Web.Endpoints.Account.Create
{
    public class CreateRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
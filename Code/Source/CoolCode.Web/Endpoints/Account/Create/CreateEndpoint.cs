namespace CoolCode.Web.Endpoints.Account.Create
{
    public class CreateEndpoint
    {
        public CreateViewModel Get()
        {
            return new CreateViewModel {Username = "", Password = "", ConfirmPassword = ""};
        }

        public CreateViewModel Post(CreateRequestModel request)
        {
            return new CreateViewModel {Username = request.Username, Password = "", ConfirmPassword = "", Message = "OK"};
        }
    }
}
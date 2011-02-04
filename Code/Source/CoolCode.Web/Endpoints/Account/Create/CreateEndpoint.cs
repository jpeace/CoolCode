using CoolCode.Web.Endpoints.Home.Index;
using FubuMVC.Core.Continuations;

namespace CoolCode.Web.Endpoints.Account.Create
{
    public class CreateEndpoint
    {
        public CreateViewModel Get()
        {
            return new CreateViewModel {Username = "", Password = "", ConfirmPassword = ""};
        }

        public Redirectable<CreateViewModel> Post(CreateRequestModel request)
        {
            var model = new CreateViewModel {Username = request.Username, Password = "", ConfirmPassword = "", Message = "OK"};
            if (request.Username == "jarrod")
            {
                return new Redirectable<CreateViewModel>(FubuContinuation.RedirectTo<IndexEndpoint>(e => e.Get()));
            }
            return new Redirectable<CreateViewModel>(model);
        }
    }
}
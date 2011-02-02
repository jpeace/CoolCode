using CoolCode.Web.Configuration.Fubu.UI.Profiles;
using CoolCode.Web.Configuration.Fubu.UI.Profiles.Default;
using FubuMVC.Core.UI;

namespace CoolCode.Web.Configuration.Fubu.UI
{
    public class CoolCodeHtmlConventions : HtmlConventionRegistry
    {
        public CoolCodeHtmlConventions()
        {
            Profile(HtmlConventionProfiles.Default, DefaultProfileConventions.Configure);
        }
    }
}
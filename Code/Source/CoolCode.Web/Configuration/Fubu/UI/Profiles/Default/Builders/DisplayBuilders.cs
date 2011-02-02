using CoolCode.Web.Configuration.Fubu.UI.Tags;
using FubuMVC.Core.UI.Configuration;
using HtmlTags;

namespace CoolCode.Web.Configuration.Fubu.UI.Profiles.Default.Builders
{
    public static class DisplayBuilders
    {
        public static HtmlTag Default(ElementRequest request)
        {
            return new SpanTag(request.ElementId).Text(request.RawValue.ToString());
        }
    }
}
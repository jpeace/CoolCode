using CoolCode.Web.Configuration.Fubu.UI.Extensions;
using CoolCode.Web.Configuration.Fubu.UI.Tags;
using FubuMVC.Core.UI.Configuration;
using HtmlTags;

namespace CoolCode.Web.Configuration.Fubu.UI.Profiles.Default.Builders
{
    public static class LabelBuilders
    {
        public static HtmlTag Default(ElementRequest request)
        {
            return new LabelTag().Text(request.Accessor.FieldName.MakeLabel()).For(request.Accessor.FieldName);
        }
    }
}
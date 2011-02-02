using FubuMVC.Core.UI.Configuration;
using HtmlTags;

namespace CoolCode.Web.Configuration.Fubu.UI.Profiles.Default.Builders
{
    public static class EditorBuilders
    {
        public static HtmlTag Default(ElementRequest request)
        {
            return new TextboxTag(request.Accessor.FieldName, request.RawValue.ToString());
        }
    }
}
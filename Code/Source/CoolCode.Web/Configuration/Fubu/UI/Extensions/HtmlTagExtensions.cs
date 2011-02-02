using HtmlTags;

namespace CoolCode.Web.Configuration.Fubu.UI.Extensions
{
    public static class HtmlTagExtensions
    {
        public static HtmlTag For(this HtmlTag tag, string @for)
        {
            tag.Attr("for", @for);
            return tag;
        }
    }
}
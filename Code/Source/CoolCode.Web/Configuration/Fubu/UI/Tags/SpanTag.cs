using HtmlTags;

namespace CoolCode.Web.Configuration.Fubu.UI.Tags
{
    public class SpanTag : HtmlTag
    {
        public SpanTag(string id)
            : base("span")
        {
            Id(id);
        }
    }
}
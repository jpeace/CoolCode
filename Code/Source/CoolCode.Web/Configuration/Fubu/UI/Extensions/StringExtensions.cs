using FubuMVC.Core.UI.Configuration;

namespace CoolCode.Web.Configuration.Fubu.UI.Extensions
{
    public static class StringExtensions
    {
        public static string MakeLabel(this string label)
        {
            return DefaultHtmlConventions.BreakUpCamelCase(label);
        }
    }
}
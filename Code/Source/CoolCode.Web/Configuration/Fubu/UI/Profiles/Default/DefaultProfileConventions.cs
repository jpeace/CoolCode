using CoolCode.Web.Configuration.Fubu.UI.Profiles.Default.Builders;
using FubuMVC.Core.UI.Tags;

namespace CoolCode.Web.Configuration.Fubu.UI.Profiles.Default
{
    public static class DefaultProfileConventions
    {
        public static void Configure(TagProfileExpression expression)
        {
            expression.Labels.Always.BuildBy(LabelBuilders.Default);
            expression.Displays.Always.BuildBy(DisplayBuilders.Default);
            expression.Editors.Always.BuildBy(EditorBuilders.Default);
        }
    }
}
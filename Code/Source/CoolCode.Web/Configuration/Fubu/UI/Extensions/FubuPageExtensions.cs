using System;
using System.Linq.Expressions;
using CoolCode.Fx;
using FubuMVC.Core.UI;
using FubuMVC.Core.View;
using HtmlTags;

namespace CoolCode.Web.Configuration.Fubu.UI.Extensions
{
    public static class FubuPageExtensions
    {
        public static HtmlTag RowFor<TModel>(this FubuPage<TModel> page, Expression<Func<TModel, object>> propertyExpression) where TModel : class
        {
            var property = new PropertyExpression<TModel>(propertyExpression);

            var ret = new DivTag(string.Format("{0}-row", property.Name));

            ret.AddClass("row");
            ret.Child(page.LabelFor(propertyExpression));
            ret.Child(page.InputFor(propertyExpression).Style("display", "inline"));

            return ret;
        }
    }
}
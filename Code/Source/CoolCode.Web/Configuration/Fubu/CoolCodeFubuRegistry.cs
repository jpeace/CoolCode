using System;
using System.Collections.Generic;
using CoolCode.Web.Configuration.Fubu.UrlPolicies;
using CoolCode.Web.Endpoints;
using FubuMVC.Core;

namespace CoolCode.Web.Configuration.Fubu
{
    public class CoolCodeFubuRegistry : FubuRegistry
    {
        public CoolCodeFubuRegistry()
        {
            IncludeDiagnostics(true);

            Applies.ToThisAssembly();

            var httpVerbs = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) { "GET", "POST" };

            Actions
                .IncludeTypes(t =>
                                    !string.IsNullOrEmpty(t.Namespace) &&
                                    t.Namespace.StartsWith(typeof(EndpointMarker).Namespace) &&
                                    t.Name.EndsWith(EndpointUrlPolicy.EndpointString)
                              )
                .IncludeMethods(a => httpVerbs.Contains(a.Method.Name));

            httpVerbs
               .Each(verb => Routes.ConstrainToHttpMethod(action => action.Method.Name.Equals(verb, StringComparison.InvariantCultureIgnoreCase), verb));

            Views.TryToAttach(findViews => findViews.by_ViewModel_and_Namespace());

            Routes
                .UrlPolicy<EndpointUrlPolicy>();
        }
    }
}
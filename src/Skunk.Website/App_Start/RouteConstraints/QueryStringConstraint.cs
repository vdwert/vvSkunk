using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

namespace Skunk.Website.App_Start.RouteConstraints
{
    public class QueryStringConstraint : IRouteConstraint
    {
        private readonly Regex _regex;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringConstraint"/> class.
        /// </summary>
        /// <param name="regex">The regex.</param>
        public QueryStringConstraint(string regex)
        {
            _regex = new Regex(regex, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Determines whether the URL parameter contains a valid value for this constraint.
        /// </summary>
        /// <param name="httpContext">An object that encapsulates information about the HTTP request.</param>
        /// <param name="route">The object that this constraint belongs to.</param>
        /// <param name="parameterName">The name of the parameter that is being checked.</param>
        /// <param name="values">An object that contains the parameters for the URL.</param>
        /// <param name="routeDirection">An object that indicates whether the constraint check is being performed when an incoming request is being handled or when a URL is being generated.</param>
        /// <returns>
        /// true if the URL parameter contains a valid value; otherwise, false.
        /// </returns>
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (httpContext.Request.QueryString.AllKeys.Contains(parameterName))
            {
                return _regex.Match(httpContext.Request.QueryString[parameterName]).Success;
            }

            return false;
        }
    }
}
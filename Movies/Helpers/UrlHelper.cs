using System.Web;

namespace Movies.Helpers
{
    public static class UrlHelper
    {
        public static string ActionRedirectToReferrer(this System.Web.Mvc.UrlHelper helper, HttpRequestBase request)
        {
            return request.UrlReferrer?.ToString() ?? helper.Action("Index", "Movies");
        }
    }
}
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Peep.Wings.Application
{
    public static class HttpContextId
    {
        public static bool IsOwn(HttpContext httpContext, string id)
        {
            return ((ClaimsIdentity)httpContext.User.Identity)
              .Claims.ToList()[0].Value == id;
        }
    }
}

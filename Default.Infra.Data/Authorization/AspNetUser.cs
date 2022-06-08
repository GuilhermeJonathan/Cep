using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Security.Claims;

namespace Default.Infra.Data.Authorization
{
    public class AspNetUser : IAspNetUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public string GetToken()
        {
            return IsAutenticated() ? _accessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "") : string.Empty;
        }

        public long GetUserId()
        {
            return IsAutenticated() ? _accessor.HttpContext.User.GetUserId() : 0;
        }

        public string GetUserMatricula()
        {
            return IsAutenticated() ? _accessor.HttpContext.User.GetUserMatricula() : "";
        }

        public string GetUserLogin()
        {
            return IsAutenticated() ? _accessor.HttpContext.User.GetUserLogin() : "";
        }

        public string GetUserNome()
        {
            return IsAutenticated() ? _accessor.HttpContext.User.GetUserNome() : "";
        }

        public bool IsAutenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> GetUserClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _accessor.HttpContext;
        }
    }
}
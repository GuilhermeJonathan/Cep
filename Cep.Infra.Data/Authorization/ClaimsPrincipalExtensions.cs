using System;
using System.Security.Claims;

namespace Cep.Infra.Data.Authorization
{
    public static class ClaimsPrincipalExtensions
    {
        public static long GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return Convert.ToInt64(claim?.Value);
        }

        public static string GetUserNome(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst(ClaimTypes.Name);
            return claim?.Value;
        }

        public static string GetUserLogin(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst("Login");
            return claim?.Value;
        }

        public static string GetUserMatricula(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst("Matricula");
            return claim?.Value;
        }
    }
}

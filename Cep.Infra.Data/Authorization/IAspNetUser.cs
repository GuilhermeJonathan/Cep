using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace Cep.Infra.Data.Authorization
{
    public interface IAspNetUser
    {
        string Name { get; }
        string GetToken();
        long GetUserId();
        string GetUserMatricula();
        string GetUserLogin();
        string GetUserNome();
        bool IsAutenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetUserClaims();
        HttpContext GetHttpContext();
    }
}

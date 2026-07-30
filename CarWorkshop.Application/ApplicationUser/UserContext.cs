using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CarWorkshop.Application.ApplicationUser;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

public class UserContext :IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CurrentUser? GetCurrentUser()
    {
        var user = _httpContextAccessor?.HttpContext?.User;
        if (user == null)
        {
            throw new InvalidCastException("User is not authenticated");
        }

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }
        var id = user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        var email = user.FindFirst(x => x.Type == ClaimTypes.Email)?.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
        return new CurrentUser(id, email,roles);
    }
}
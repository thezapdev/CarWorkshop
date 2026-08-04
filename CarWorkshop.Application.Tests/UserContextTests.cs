using System.Security.Claims;
using CarWorkshop.Application.ApplicationUser;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;

namespace CarWorkshop.Application.Test;

public class UserContextTests
{
    [Fact()]
    public void GetCurrentUser_ShouldReturnCurrentUser()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim(ClaimTypes.Email, "test@example.com"),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(ClaimTypes.Role, "User")
        };
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "TestAuthentication"));
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
        {
            User = user
        });
        var userContext = new UserContext(httpContextAccessorMock.Object);
        // act 
        var currentUser = userContext.GetCurrentUser();
        // Assert
        currentUser.Should().NotBeNull();
        currentUser.Id.Should().Be("1");
        currentUser.Email.Should().Be("test@example.com");
        currentUser.Roles.Should().ContainInOrder("Admin", "User");
    }
}
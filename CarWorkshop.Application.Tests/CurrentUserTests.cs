using CarWorkshop.Application.ApplicationUser;
using FluentAssertions;

namespace CarWorkshop.Application.Test;

public class CurrentUserTests
{
    [Fact]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue()
    {
        // Arrange
        CurrentUser user = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User" });

        // Act 
        var isInRole = user.IsInRole("Admin");
        
        // Assert 
        isInRole.Should().BeTrue();
    }
    [Fact]
    public void IsInRole_WithNonMatchingRole_ShouldReturnFalse()
    {
        // Arrange
        CurrentUser user = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User" });

        // Act 
        var isInRole = user.IsInRole("Moderator");
        
        // Assert 
        isInRole.Should().BeFalse();
    }
    public void IsInRole_WithNonMatchingCaseRole_ShouldReturnFalse()
    {
        // Arrange
        CurrentUser user = new CurrentUser("1", "test@tests.com", new List<string> { "Admin", "User" });

        // Act 
        var isInRole = user.IsInRole("admin");
        
        // Assert 
        isInRole.Should().BeFalse();
    }
}
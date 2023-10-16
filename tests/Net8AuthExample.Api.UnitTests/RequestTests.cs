using System.ComponentModel.DataAnnotations;
using FluentValidation.TestHelper;
using Net8AuthExample.Api;

namespace Net8AuthExample.ApiTests;

public class RequestTests
{
    [Fact]
    public void CreateInvalidRequest_WithRangeAttribute_Fails()
    {
        // Arrange
        var request = new Request { PersonalId = 0 };
        var validationContext = new ValidationContext(request);
        
        // Act
        var result = Validator.TryValidateObject(request, validationContext, new List<ValidationResult>(), true);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void CreateValidRequest_WithRangeAttribute_Succeeds()
    {
        // Arrange
        var request = new Request { PersonalId = 1 };
        var validationContext = new ValidationContext(request);
        
        // Act
        var result = Validator.TryValidateObject(request, validationContext, new List<ValidationResult>(), true);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CreateValidRequest_WithValidator_Succeeds()
    {
        // Arrange
        var validator = new RequestValidator();
        var request = new Request { PersonalId = 1 };
        
        // Act
        var result = validator.TestValidate(request);
        
        // Assert
        Assert.True(result.IsValid);
    }
    
    [Fact]
    public void CreateInvalidRequest_WithValidator_Fails()
    {
        // Arrange
        var validator = new RequestValidator();
        var request = new Request { PersonalId = 0 };
        
        // Act
        var result = validator.TestValidate(request);
        
        // Assert
        Assert.False(result.IsValid);
    }
}
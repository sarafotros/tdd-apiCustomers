using CloudCustmers.UnitTests.Fixtures;
using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(x => x.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers());
        
        var stu = new UsersController(mockUsersService.Object);
        // Act
        var result = (OkObjectResult) await stu.Get();
        //Assert
        result.StatusCode.Should().Be(200);

    }
    
    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceExactly()
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(x => x.GetAllUsers())
            .ReturnsAsync(new List<User>());
        
        
        var stu = new UsersController(mockUsersService.Object);
        
        // Act
        var result =  await stu.Get();
        //Assert
        mockUsersService.Verify(x => x.GetAllUsers(), Times.Once());
    }
    
    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();
        
        mockUsersService
            .Setup(x => x.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers());
        
        
        var stu = new UsersController(mockUsersService.Object);
        
        // Act
        var result =  await stu.Get();
        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }
    
    [Fact]
    public async Task Get_OnNoUsersFound_Returns404()
    {
        //Arrange
        var mockUsersService = new Mock<IUsersService>();
        
        mockUsersService
            .Setup(x => x.GetAllUsers())
            .ReturnsAsync(new List<User>());
        
        
        var stu = new UsersController(mockUsersService.Object);
        
        // Act
        var result =  await stu.Get();
        //Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}
using CloudCustomers.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class UnitTest1
{
    //Arrange
    // Act
    //Assert
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var stu = new UsersController();
        // Act
        var result = (OkObjectResult) await stu.Get();
        //Assert
        result.StatusCode.Should().Be(200);

    }
}
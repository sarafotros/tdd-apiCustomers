using CloudCustmers.UnitTests.Fixtures;
using CloudCustmers.UnitTests.Helpers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using FluentAssertions;
using Moq;
using Moq.Protected;

namespace CloudCustmers.UnitTests.Systems.Services;

public class TestUsersService
{
    [Fact]
    public async Task GetAllUsers_WhenCalled_InvokeHttpGetRequest()
    {
        //Arrange
        var expectedResponse = UsersFixture.GetTestUsers();
        var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var stu = new UsersService(httpClient);
        
        // Act
        await stu.GetAllUsers();

        //Assert
        handlerMock
            .Protected()
            .Verify(
                "SendAsync", 
                Times.Exactly(1), 
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
        ItExpr.IsAny<CancellationToken>()
                );
    }
    
    
    [Fact]
    public async Task GetAllUsers_WhenCalled_ListOfUsers()
    {
        //Arrange
        var expectedResponse = UsersFixture.GetTestUsers();
        var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var stu = new UsersService(httpClient);
        
        // Act
        var result = await stu.GetAllUsers();

        //Assert
        result.Should().BeOfType<List<User>>();
    }
}
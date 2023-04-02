using CloudCustomers.API.Models;

namespace CloudCustmers.UnitTests.Fixtures;

public class UsersFixture
{
    public static List<User> GetTestUsers() =>
        new()
        {
            new User()
            {
                Id = 1,
                Name = "Sara",
                Email = "sara.test@test.com",
                Address = new Address()
                {
                    Street = "street test",
                    City = "London",
                    PostCode = "EC1"
                }
            },
            new User()
            {
                Id = 2,
                Name = "John",
                Email = "ja.test@test.com",
                Address = new Address()
                {
                    Street = "street2",
                    City = "London",
                    PostCode = "EC1"
                }
            },
            new User()
            {
                Id = 3,
                Name = "Jack",
                Email = "jk.test@test.com",
                Address = new Address()
                {
                    Street = "somewhere",
                    City = "London",
                    PostCode = "EC2"
                }
            }

        };
}
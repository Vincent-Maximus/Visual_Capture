using System;
using Moq;
using Xunit;

namespace Visual_Capture.Unit_Tests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
    }
    
    [TestMethod()]
    public void Register_ShouldCreateUserWhenGivenUserHasValidFields_Test()
    {
        // Arrange
        User user = new User()
        {
            Email = "unieke@mail.com",
            Name = "Robin M",
            Password = "VeryStrongSixPlusDigitPassword123",
            Role = Enums.Roles.User
        };

        _userRepoMock.Setup(r => r.GetByEmail(user.Email))
            .Returns(() => null);

        _userRepoMock.Setup(r => r.Create(It.IsAny<UserDTO>()))
            .Returns(true);


        // Act
        MethodResult result = _userService.Register(user);

        // Assert
        _userRepoMock.Verify(r => r.Create(It.IsAny<UserDTO>()), Times.Once());
        Assert.AreEqual(new MethodResult.Success(), result);
    }

    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _userRepoMock = new Mock<IUserRepository>();

        public UserServiceTests()
        {
            _userService = new UserService(_userRepoMock.Object);
        }
    }
    
}
using AutoMapper;
using GamesPlatform.Infrastructure.AutoMappers;
using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Infrastructure.Repositiories;
using GamesPlatform.Infrastructure.Services;
using Moq;

namespace GamesPlatform.Tests
{
    public class UserServiceTests
    {
        private IUserService _userService;
        private Mock<UserRepository> _mockUserRepository;
        private IMapper _mapper;
        
        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<UserRepository>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = mockMapper.CreateMapper();
            
            _userService = new UserService(_mockUserRepository.Object, _mapper);
        }

        [Test]
        public async Task RegisterUser_ThenGetRegisteredUser_ServiceResponseIsSuccessful()
        {
            // Arrange
            var testEmail = "test@test.com";

            await _userService.RegisterAsync(Guid.NewGuid(), testEmail, "TestUsername", "secret", new DateTime(2000, 01, 01));

            // Act
            var serviceResponse = await _userService.GetUserAsync(testEmail);
            
            // Assert
            Assert.That(serviceResponse.IsSuccess, Is.True);
        }

        [Test]
        public async Task GetUserByEmail_OnInvalidEmail_ReturnsUnsuccessfulResponse()
        {
            // Arrange
            var testEmail = "test@test.com";
            await _userService.RegisterAsync(Guid.NewGuid(), testEmail, "TestUsername", "secret", new DateTime(2000, 01, 01));

            // Act
            var serviceResponse = await _userService.GetUserAsync("anotherTest@test.pl");
            
            // Assert
            Assert.That(serviceResponse.IsSuccess, Is.False);
        }
    }
}

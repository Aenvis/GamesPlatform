using AutoMapper;
using GamesPlatform.Infrastructure.AutoMappers;
using GamesPlatform.Infrastructure.Consts;
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
        private IEncrypter _encrypter;
        
        [SetUp]
        public void Setup()
        {
            // TODO: implement FakeDbSet class so it is possible to pass FakeDbContext to UserRepository 
            _mockUserRepository = new Mock<UserRepository>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = mockMapper.CreateMapper();
            _encrypter = new Encrypter();
            
            _userService = new UserService(_mockUserRepository.Object, _mapper, _encrypter);
        }

        [Test]
        public async Task RegisterUser_ThenGetRegisteredUser_AssertThatServiceResponseIsSuccessful()
        {
            // Arrange
            var testEmail = "test@test.com";

            // Act
            await _userService.RegisterAsync(Guid.NewGuid(), testEmail, "TestUsername", "secret");
            var serviceResponse = await _userService.GetUserAsync(testEmail);
            
            // Assert
            Assert.That(serviceResponse.IsSuccess, Is.True);
        }

        [Test]
        public async Task GetUserByEmail_OnInvalidEmail_ReturnsUnsuccessfulResponse()
        {
            // Arrange
            var testEmail = "test@test.com";
            await _userService.RegisterAsync(Guid.NewGuid(), testEmail, "TestUsername", "secret");

            // Act
            var serviceResponse = await _userService.GetUserAsync("anotherTest@test.pl");
            
            // Assert
            Assert.That(serviceResponse.IsSuccess, Is.False);
        }
    }
}

using System.Web.Mvc;
using CaptchaMvc.Interface;
using CodeChallange.Entity;
using CodeChallange.Service.UserService;
using CodeChallenge.Data.CoreRepository;
using CodeChallenge.Data.UserRepository;
using Moq;

namespace CodeChallange.Tests.Home
{
    public class TestableHomeController
    {
        public Mock<IUserService> _userServiceMock;
        public Mock<IRepository<User>> _repositoryMock;
        public Mock<IUserRepository> _userRepository;
        public Mock<IUpdateInfoModel> _captchaMock;
        public Mock<UI.Controllers.HomeController> _homeControllerMock;        

        public TestableHomeController(Mock<IUserService> userServiceMock,
            Mock<IRepository<User>> repositoryMock,
            Mock<IUserRepository> userRepository,
            Mock<IUpdateInfoModel> captchaMock,
            Mock<UI.Controllers.HomeController> homeControllerMock)
        {
            _userServiceMock = userServiceMock;
            _repositoryMock = repositoryMock;
            _userRepository = userRepository;
            _captchaMock = captchaMock;
            _homeControllerMock = homeControllerMock;
        }

        public static TestableHomeController Create()
        {
            return new TestableHomeController(new Mock<IUserService>(),
                new Mock<IRepository<User>>(),
                new Mock<IUserRepository>(),
                new Mock<IUpdateInfoModel>(),
                new Mock<UI.Controllers.HomeController>());
        }
    }
}
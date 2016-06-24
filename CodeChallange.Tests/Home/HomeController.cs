using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc.Interface;
using CaptchaMvc.Models;
using CodeChallange.Entity;
using CodeChallange.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodeChallange.Tests.Home
{
    [TestClass]
    public class HomeController
    {
        // Captcha ürünü içinde static extentionlar oldugundan mocklanmıyor.
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldGetNullExceptionIfValidCreateUser()
        {
            var mockController = TestableHomeController.Create();

            UI.Controllers.HomeController controller = new UI.Controllers.HomeController(
                mockController._userServiceMock.Object);

            controller.Create(It.IsAny<User>());

            Assert.IsTrue(controller.ModelState.IsValid);
            mockController._userServiceMock.Verify(x => x.AddUser(It.IsAny<User>()), Times.Once);
            mockController._homeControllerMock.Verify(x => x.GenerateCaptchaValue(It.IsAny<int>()), Times.Never);
        }
        // Captcha ürünü içinde static extentionlar oldugundan mocklanmıyor.
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldGetNotSupportedExceptionIfInValidCreateUser()
        {
            var mockController = TestableHomeController.Create();

            UI.Controllers.HomeController controller = new UI.Controllers.HomeController(
                mockController._userServiceMock.Object);

            controller.ModelState.AddModelError("key", "Invalid input captcha");
            controller.Create(It.IsAny<User>());

            Assert.IsFalse(controller.ModelState.IsValid);
            mockController._userServiceMock.Verify(x => x.AddUser(It.IsAny<User>()), Times.Never);
            mockController._homeControllerMock.Verify(x => x.GenerateCaptchaValue(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void ShouldGetTotalCountAndListUserWhenCallIndex()
        {
            var mockController = TestableHomeController.Create();

            UI.Controllers.HomeController controller = new UI.Controllers.HomeController(
                mockController._userServiceMock.Object);

            controller.Index();
            mockController._userServiceMock.Verify(x => x.GetTotalCount(), Times.Once);
            mockController._userServiceMock.Verify(x => x.ListUser(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Expression<Func<User, string>>>()), Times.Once);
        }

        [TestMethod]
        public void ShouldGetTotalCountAndListUserWhenCallRead()
        {
            var mockController = TestableHomeController.Create();

            UI.Controllers.HomeController controller = new UI.Controllers.HomeController(
                mockController._userServiceMock.Object);

            var result = (PartialViewResult)controller.Read();

            Assert.AreEqual("_Details", result.ViewName);
            mockController._userServiceMock.Verify(x => x.GetTotalCount(), Times.Once);
            mockController._userServiceMock.Verify(x => x.ListUser(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Expression<Func<User, string>>>()), Times.Once);
        }

        [TestMethod]
        public void ShouldViewNameAsCreateWhenCallCreate()
        {
            var mockController = TestableHomeController.Create();

            UI.Controllers.HomeController controller = new UI.Controllers.HomeController(
                mockController._userServiceMock.Object);

            var result = (ViewResult)controller.Create();

            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void ShouldUpdateUserWhenCallUpdate()
        {
            var mockController = TestableHomeController.Create();

            UI.Controllers.HomeController controller = new UI.Controllers.HomeController(
                mockController._userServiceMock.Object);

            controller.Update(It.IsAny<User>());
            mockController._userServiceMock.Verify(x => x.UpdateUser(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public void ShouldGetUserWhenCallGetUpdateUser()
        {
            var mockController = TestableHomeController.Create();

            UI.Controllers.HomeController controller = new UI.Controllers.HomeController(
                mockController._userServiceMock.Object);

            controller.Update(It.IsAny<int>());
            mockController._userServiceMock.Verify(x => x.GetUser(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void ShouldDeleteUserWhenCallDeleteUser()
        {
            var mockController = TestableHomeController.Create();

            UI.Controllers.HomeController controller = new UI.Controllers.HomeController(
                mockController._userServiceMock.Object);

            controller.Delete(It.IsAny<int>());
            mockController._userServiceMock.Verify(x => x.DeleteUser(It.IsAny<int>()), Times.Once);
        }
    }
}

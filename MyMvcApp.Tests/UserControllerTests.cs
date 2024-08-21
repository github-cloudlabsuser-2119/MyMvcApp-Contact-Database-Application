using Xunit;
using MyMvcApp.Controllers;
using MyMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MyMvcApp.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void Index_ReturnsViewWithUserList()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.IsType<System.Collections.Generic.List<User>>(result.Model);
        }

        [Fact]
        public void Details_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1 };

            // Act
            var result = controller.Details(user.Id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.IsType<User>(result.Model);
            Assert.Equal(user.Id, ((User)result.Model).Id);
        }

        [Fact]
        public void Details_ReturnsNotFoundForInvalidId()
        {
            // Arrange
            var controller = new UserController();
            var invalidId = 999;

            // Act
            var result = controller.Details(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John", Email = "john@example.com" };

            // Act
            var result = controller.Create(user) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Edit_ReturnsViewResult()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John", Email = "john@example.com" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Edit(user) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

                [Fact]
                
        public void Delete_User_Returns_ViewResult()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John", Email = "john@example.com" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_ReturnsViewResult()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John", Email = "john@example.com" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        // Add more test cases for other methods in the UserController class
    }
}
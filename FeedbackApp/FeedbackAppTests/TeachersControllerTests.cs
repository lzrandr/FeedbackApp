using AutoMapper;
using Feedback.Data;
using Feedback.Domain.Models;
using FeedbackWeb.Areas.Admin.Controllers;
using FeedbackWeb.Controllers;
using Moq;
using System;
using Xunit;

namespace FeedbackAppTests
{
    public class TeachersControllerTests

    {
        [Fact]
        public void DeleteTeacher_WhenCalled_DeleteTheTeacheFromD()
        {
            // Arrange 
            var repository = new Mock<ITeacherRepository>();
            var mapper = new Mock<IMapper>();
            var controller = new TeachersController(repository.Object, mapper.Object);

            // Act
            controller.DeleteConfirmed(3);

            // Assert
            repository.Verify(s => s.DeleteTeacher(3));
        }
    }
}

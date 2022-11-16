using CandidateTestTask.Builder;
using CandidateTestTask.Controllers;
using CandidateTestTask.Custom;
using CandidateTestTask.Models;
using CandidateTestTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text;
using System.Web.Http.Results;

namespace CandidateTestTask.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Hieu", "Bui", "0354123456", "hieuden0@gmail.com", "2pm to 6pm", "http://github.com", "http://linkedin.com", "free text")]
        public void Create_Candidate_Return_OK(string firstname, string lastname, string phoneNumber, string email, string timeIntervalToCall, string linkedInProfile, string githubProfile, string freeTextComment)
        {
            //Arrange   
            var logger = Mock.Of<ILogger<CandidateController>>();
            var candidateService = new CandidateService();

            var _controller = new CandidateController(logger, candidateService);
            var _model = new CandidateBuilder()
             .AddFirstname(firstname)
             .AddLastname(lastname)
             .AddEmail(email)
             .AddPhoneNumber(phoneNumber)
             .AddTimeIntervalToCall(timeIntervalToCall)
             .AddGithubProfileUrl(githubProfile)
             .AddLinkedInProfileUrl(linkedInProfile)
             .AddFreeTextComment(freeTextComment).Build();

            //ACT
            var result = _controller.Create(_model);

            //ASSERT
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        [TestCase("Hieu", null, "", "", "", "", "", "")]
        public void Create_Candidate_Return_Not_OK(string firstname, string lastname, string phoneNumber, string email, string timeIntervalToCall, string linkedInProfile, string githubProfile, string freeTextComment)
        {
            //Arrange   
            var logger = Mock.Of<ILogger<CandidateController>>();
            var candidateService = new CandidateService();

            var _controller = new CandidateController(logger, candidateService);
            var _model = new CandidateBuilder()
                .AddFirstname(firstname)
                .AddLastname(lastname)
                .AddEmail(email)
                .AddPhoneNumber(phoneNumber)
                .AddTimeIntervalToCall(timeIntervalToCall)
                .AddGithubProfileUrl(githubProfile)
                .AddLinkedInProfileUrl(linkedInProfile)
                .AddFreeTextComment(freeTextComment).Build();
            
            _controller.ModelState.AddModelError("", "invalid data");

            //ACT
            var result = _controller.Create(_model);

            //ASSERT
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void Invalid_ModelState_Should_Return_BadRequestObjectResult()
        {
            //Arrange
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("", "error");
            var httpContext = new DefaultHttpContext();
            var context = new ActionExecutingContext(
                new ActionContext(
                    httpContext: httpContext,
                    routeData: new RouteData(),
                    actionDescriptor: new ActionDescriptor(),
                    modelState: modelState
                ),
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                new Mock<Controller>().Object);

            var sut = new CustomModelValidate();

            //Act
            sut.OnActionExecuting(context);

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(context.Result);

        }


    }
}
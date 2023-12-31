﻿namespace Rabotilnik.Web.Tests.Controllers
{
    using System.Collections.Generic;

    using Rabotilnik.Data.Models;
    using Rabotilnik.Services.Interfaces;
    using Rabotilnik.Web.Controllers;
    using Rabotilnik.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Identity;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ReviewsControllerTests
    {
        [Fact]
        public void LeaveReviewShouldReturnCorrectRedirectWhenUserIsFreelancer()
            => MyController<ReviewsController>
                .Instance(
                    controller => controller
                        .WithDependencies(
                            From.Services<IFreelancePlatform>(),
                            From.Services<UserManager<ApplicationUser>>())
                        .WithData(
                            new Employer()
                            {
                                Id = "123Test",
                                UserName = "tonsan2",
                                FirstName = "Test",
                                Roles = new List<IdentityUserRole<string>>()
                                {
                                    new IdentityUserRole<string>()
                                    {
                                        RoleId = "4dc5dea8-00cc-44e4-b626-451ce0b6c0ae",
                                    },
                                },
                            },
                            new Employer()
                            {
                                Id = "test123",
                                UserName = "tonsan1",
                                FirstName = "Test",
                                Roles = new List<IdentityUserRole<string>>()
                                {
                                    new IdentityUserRole<string>()
                                    {
                                        RoleId = "4dc5dea8-00cc-44e4-b626-451ce0b6c0ae",
                                    },
                                },
                            })
                        .WithUser(
                            user => user
                                .WithIdentifier("test123")
                                .WithUsername("tonsan1")
                                .InRole("Employer")))
                .Calling(
                    x => x.LeaveReview(
                        new ReviewInputModel()
                        {
                            Rating = 4,
                            SenderId = "test123",
                            RecipientId = "123Test",
                            Text = "babababababbaba",
                        }))
                .ShouldHave()
                .ActionAttributes(
                    attributes => attributes
                        .RestrictingForAuthorizedRequests()
                        .RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Employer", "Users", new { id = "123Test" });
    }
}

namespace Rabotilnik.Web.Controllers
{
    using System.Threading.Tasks;

    using Rabotilnik.Data.Models;
    using Rabotilnik.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class NotificationsController : BaseController
    {
        private readonly IFreelancePlatform freelancePlatform;
        private readonly UserManager<ApplicationUser> userManager;

        public NotificationsController(
            IFreelancePlatform freelancePlatform,
            UserManager<ApplicationUser> userManager)
        {
            this.freelancePlatform = freelancePlatform;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "Employer, Freelancer")]
        public async Task<IActionResult> MarkNotificationAsRead([FromBody] string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var notificationsCount = this.freelancePlatform.NotificationManager.GetNotificationsCount(userId);
            await this.freelancePlatform.NotificationManager.MarkNotificationAsReadAsync(id);

            return this.Json(new { count = notificationsCount });
        }
    }
}

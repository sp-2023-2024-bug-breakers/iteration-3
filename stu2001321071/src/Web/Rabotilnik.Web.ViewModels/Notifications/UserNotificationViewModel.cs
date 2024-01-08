namespace Rabotilnik.Web.ViewModels.Notifications
{
    using Rabotilnik.Data.Models;
    using Rabotilnik.Services.Mapping;

    public class UserNotificationViewModel : IMapFrom<Notification>
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string Icon { get; set; }

        public string RedirectAction { get; set; }

        public string RedirectController { get; set; }

        public string RedirectId { get; set; }
    }
}

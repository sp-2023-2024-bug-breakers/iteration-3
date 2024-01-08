namespace Rabotilnik.Web.ViewModels.Notifications
{
    using Rabotilnik.Data.Models;
    using Rabotilnik.Services.Mapping;

    public class JobNotificationViewModel : IMapFrom<Job>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string EmployerId { get; set; }
    }
}

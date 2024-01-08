namespace Rabotilnik.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Rabotilnik.Data.Models;

    public interface INotificationManager
    {
        Task CreateAsync(Notification notification, string userId);

        Task MarkNotificationAsReadAsync(string notificationId);

        Task MarkAllNotificationsAsReadAsync(string userId);

        Task<IEnumerable<T>> GetAllUserNotificationsAsync<T>(string userId);

        int GetNotificationsCount(string userId);
    }
}

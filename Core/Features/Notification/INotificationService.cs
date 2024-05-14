using Common.Bases;

namespace Core.Features.Notification;

public interface INotificationService : ITransient
{
    public Task SendNotification(NotificationClass notification);
}
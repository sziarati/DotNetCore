
using Common.Bases;

namespace Core.Features.Notification;

public interface INotificationHandler : ITransient
{
    void SetNext(INotificationHandler handler);
    Task Handle(NotificationClass notification);
}

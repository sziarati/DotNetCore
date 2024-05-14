using Core.Features.Notification;

namespace Infra.Notification;

public class SmsNotificationHandler : INotificationHandler
{
    private INotificationHandler? _nextHandler;

    public void SetNext(INotificationHandler handler)
    {
        _nextHandler = handler;
    }

    public async Task Handle(NotificationClass notification)
    {
        if (notification is null)
        {
            throw new ArgumentNullException(nameof(notification));
        }

        if (notification.Types != null && notification.Types.Contains(NotificationType.SMS))
        {
            Console.WriteLine($"Sending SMS to {notification.RecieverMobileNumber}: {notification.Message}");
        }

        if(_nextHandler != null)
        {
            await _nextHandler.Handle(notification);
        }
    }
}

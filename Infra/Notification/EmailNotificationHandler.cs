using Core.Features.Notification;
using System.Runtime.CompilerServices;

namespace Infra.Notification;

public class EmailNotificationHandler : INotificationHandler
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

        if (notification.Types != null && notification.Types.Contains(NotificationType.EMAIL))
        {
            Console.WriteLine($"Sending email to {notification.RecieverEmail}: {notification.Message}");
        }

        if (_nextHandler != null)
        {
            await _nextHandler.Handle(notification);
        }
    }
}

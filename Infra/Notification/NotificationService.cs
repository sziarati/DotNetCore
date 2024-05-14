using Core.Features.Notification;

namespace Infra.Notification;

public class NotificationService : INotificationService
{
    private INotificationHandler _chain;

    public NotificationService()
    {
        var emailHandler = new EmailNotificationHandler();
        var smsHandler = new SmsNotificationHandler();

        emailHandler.SetNext(smsHandler);

        _chain = emailHandler;
    }

    public async Task SendNotification(NotificationClass notification)
    {
        await _chain.Handle(notification);
    }
}

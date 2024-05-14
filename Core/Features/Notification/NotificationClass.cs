namespace Core.Features.Notification;

public class NotificationClass
{
    public List<NotificationType>? Types { get; set; }
    public string? RecieverEmail { get; set; }
    public string? RecieverMobileNumber { get; set; }
    public string? Subject { get; set; }

    public string? Message { get; set; }
}

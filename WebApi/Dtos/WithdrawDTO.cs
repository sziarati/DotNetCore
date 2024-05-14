using Core.Features.Notification;

namespace WebApi.Dtos;

public class WithdrawDto
{
    public Guid FromAccount { get; set; }
    public Guid ToAccount { get; set; }
    public double Balance { get; set; }
    public List<NotificationType>? Types { get; set; }
}
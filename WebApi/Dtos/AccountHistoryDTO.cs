namespace WebApi.Dtos;

public record AccountHistoryDto(Guid AccountGuid, DateTime ValidFrom, DateTime ValidTo);

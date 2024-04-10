namespace WebApi.Dtos;

public record AccountHistoryDTO(Guid AccountGuid, DateTime ValidFrom, DateTime ValidTo);

namespace PJATK_APBD_Cw4_s29792.DTOs;

public record PcComponentsResponse(
    int Id,
    string Name,
    decimal Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PcComponentItemDto> Components);

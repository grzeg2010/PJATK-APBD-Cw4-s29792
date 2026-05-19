namespace PJATK_APBD_Cw4_s29792.DTOs;

public record ComponentDetailDto(
    string Code,
    string Name,
    string Description,
    ManufacturerDto Manufacturer,
    ComponentTypeDto Type);

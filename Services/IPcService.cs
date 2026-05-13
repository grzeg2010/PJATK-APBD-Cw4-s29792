using PJATK_APBD_Cw4_s29792.DTOs;

namespace PJATK_APBD_Cw4_s29792.Services;

public interface IPcService
{
    Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<PcComponentsResponse> GetComponentsAsync(int id, CancellationToken cancellationToken);
}
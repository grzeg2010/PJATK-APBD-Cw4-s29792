using PJATK_APBD_Cw4_s29792.DTOs;

namespace PJATK_APBD_Cw4_s29792.Services;

public interface IPcService
{
    Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<PcResponse> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PcComponentsResponse> GetComponentsAsync(int id, CancellationToken cancellationToken);
    Task<PcResponse> AddAsync(CreatePcRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
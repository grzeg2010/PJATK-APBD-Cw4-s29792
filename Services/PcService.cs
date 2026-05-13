using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw4_s29792.DTOs;
using PJATK_APBD_Cw4_s29792.Exceptions;
using PJATK_APBD_Cw4_s29792.Infrastructure;

namespace PJATK_APBD_Cw4_s29792.Services;

public class PcService(AppDbContext ctx) : IPcService
{
    public async Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.Pcs.Select(pc => new PcResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
            )).ToListAsync(cancellationToken);
    }

    public async Task<PcComponentsResponse> GetComponentsAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.Pcs
            .Where(e => e.Id == id)
            .Select(pc => new PcComponentsResponse(
                pc.PcComponents.Select(comp => new ComponentResponse(
                    comp.ComponentCode,
                    comp.Component.Name,
                    comp.Component.Description))
                )).FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"PC with id {id} not found");
    }
}
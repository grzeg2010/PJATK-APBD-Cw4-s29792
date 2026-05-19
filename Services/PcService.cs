using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw4_s29792.DTOs;
using PJATK_APBD_Cw4_s29792.Exceptions;
using PJATK_APBD_Cw4_s29792.Infrastructure;
using PJATK_APBD_Cw4_s29792.Models;

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

    public async Task<PcResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.Pcs
                   .Where(e => e.Id == id)
                   .Select(pc => new PcResponse(
                       pc.Id,
                       pc.Name,
                       pc.Weight,
                       pc.Warranty,
                       pc.CreatedAt,
                       pc.Stock
                   )).FirstOrDefaultAsync(cancellationToken)
               ?? throw new NotFoundException($"PC with id {id} not found");
    }

    public async Task<PcComponentsResponse> GetComponentsAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.Pcs
            .Where(e => e.Id == id)
            .Select(pc => new PcComponentsResponse(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,
                pc.PcComponents.Select(comp => new PcComponentItemDto(
                    comp.Amount,
                    new ComponentDetailDto(
                        comp.Component.Code,
                        comp.Component.Name,
                        comp.Component.Description,
                        new ManufacturerDto(
                            comp.Component.ComponentManufacturer.Id,
                            comp.Component.ComponentManufacturer.Abbreviation,
                            comp.Component.ComponentManufacturer.FullName,
                            comp.Component.ComponentManufacturer.FoundationDate),
                        new ComponentTypeDto(
                            comp.Component.ComponentType.Id,
                            comp.Component.ComponentType.Abbreviation,
                            comp.Component.ComponentType.Name))))
            )).FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"PC with id {id} not found");
    }

    public async Task<PcResponse> AddAsync(CreatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = new Pc
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);

        return new PcResponse(pc.Id, pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.Pcs.Where(e => e.Id == id)
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.Name, request.Name)
                    .SetProperty(e => e.Weight, request.Weight)
                    .SetProperty(e => e.Warranty, request.Warranty)
                    .SetProperty(e => e.CreatedAt, request.CreatedAt)
                    .SetProperty(e => e.Stock, request.Stock),
                cancellationToken
            );

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.Pcs
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
        
        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PJATK_APBD_Cw4_s29792.DTOs;

public record CreatePcRequest(
    [MaxLength(50)] string Name,
    decimal Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
    );
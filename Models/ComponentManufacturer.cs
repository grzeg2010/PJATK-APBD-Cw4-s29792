using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw4_s29792.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    
    [MaxLength(300)]
    public string FullName { get; set; } = string.Empty;
    
    public DateOnly Date { get; set; }
    
    public IEnumerable<Component> Components { get; set; } = [];
}
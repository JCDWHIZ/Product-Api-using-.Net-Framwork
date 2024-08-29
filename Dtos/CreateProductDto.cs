using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public record class CreateProductDto(
    int Id, 
    [Required][StringLength(50)] string Name, 
   [Required][Range(1, 100)] Decimal CurrentPrice, 
    [Required][Range(1, 100)]Decimal OldPrice,
     [Required] string Description, 
     [Required] decimal Rating,
    [Required] string BackdropUrl,
     int CategoryId
);

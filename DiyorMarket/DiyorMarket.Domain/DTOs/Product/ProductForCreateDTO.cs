namespace DiyorMarket.Domain.DTOs.Product
{
    public record ProductForCreateDTO(
       string Name,
       string Description,
       decimal Price,
       DateTime ExpireDate,
       int CategoryId
       );
}

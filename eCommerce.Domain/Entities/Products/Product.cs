using eCommerce.Domain.Commons;
using System.Reflection.PortableExecutable;

namespace eCommerce.Domain.Entities;

public class Product : Auditable
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public string Description { get; set; } = string.Empty;
    public string SearchByTag { get; set; } = string.Empty; 


}

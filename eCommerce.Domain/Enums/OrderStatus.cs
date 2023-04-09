namespace eCommerce.Domain.Enums;

public enum OrderStatus : byte
{
    Pending,
    Picking,
    Packing,
    Shipping,
    Shipped,
    Cancelled
}
﻿using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities.Products;

public class ProductComment : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; } = default!;
    public long ProductId { get; set; }
    public Product Product { get; set; } = default!;

    public string Comment { get; set; } = string.Empty;
}

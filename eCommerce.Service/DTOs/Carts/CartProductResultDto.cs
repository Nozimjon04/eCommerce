using eCommerce.Domain.Entities.Carts;
using eCommerce.Domain.Entities;

namespace eCommerce.Service.DTOs.Charts
{
    public class CartProductResultDto
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public Cart? Cart { get; set; }
        public long ProductId { get; set; }
        public Product? Product { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime? UpdateAt { get; set; }
	}
}

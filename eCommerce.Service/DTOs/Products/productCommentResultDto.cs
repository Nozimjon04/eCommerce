using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using eCommerce.Domain.Entities;

namespace eCommerce.Service.DTOs.Products
{
    public class productCommentResultDto
    {
		public long Id { get; set; }
		public long UserId { get; set; }
		public User? User { get; set; }
		public long ProductId { get; set; }
		public Product? Product { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime? UpdateAt { get; set; }

		public string Comment { get; set; } = string.Empty;
	}
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eCommerce.Service.DTOs.Products
{
    public class productCommentResultDto
    {
		public long Id { get; set; }
		public long UserId { get; set; }
		public long ProductId { get; set; }
		public string Comment { get; set; } = string.Empty;
	}
}

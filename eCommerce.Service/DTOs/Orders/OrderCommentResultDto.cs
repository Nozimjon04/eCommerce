using eCommerce.Domain.Entities;

namespace eCommerce.Service.DTOs.Orders
{
    public class OrderCommentResultDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long OrderId { get; set; }

        // To leave Comment
        public string Comment { get; set; } = string.Empty;
    }
}

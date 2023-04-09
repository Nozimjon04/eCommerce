using eCommerce.Domain.Entities;

namespace eCommerce.Service.DTOs.Orders
{
    public class OrderCommentResultDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public long OrderId { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime? UpdateAt { get; set; }


		// To leave Comment
		public string Comment { get; set; } = string.Empty;

        public string AnswerMessage { get; set; }= string.Empty;
    }
}

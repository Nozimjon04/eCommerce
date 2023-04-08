
using eCommerce.Domain.Entities;

namespace eCommerce.Service.DTOs.Charts
{
    public class CartForResultDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
}

using eCommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eCommerce.Service.DTOs.Orders
{
    public class OrderCommentCreationDto
    {
        [DisplayName("User Id")]
        [Required]
        public long UserId { get; set; }
        [Required]
        [DisplayName("Order Id")]

        public long OrderId { get; set; }

        [Required(ErrorMessage = "Please Enter Comment")]
        [DisplayName("Comment")]
        public string Comment { get; set; } = string.Empty;
    }
}

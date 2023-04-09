using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.DTOs.Payments
{
    public class PaymentCreationDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public long OrderId { get; set; }
    }
}

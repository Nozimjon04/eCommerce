﻿using eCommerce.Domain.Entities;
using eCommerce.Domain.Enums;

namespace eCommerce.Service.DTOs.Orders
{
    public class OrderForResultDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime? UpdateAt { get; set; }
        public bool IsPaid { get; set; } = false;
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

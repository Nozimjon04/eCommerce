using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eCommerce.Service.Services;

public class PaymentService
{
    private readonly IRepository<Payment> repository;
    private readonly IMapper mapper;

   
}

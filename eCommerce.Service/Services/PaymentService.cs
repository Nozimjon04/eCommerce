using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Payments;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eCommerce.Service.Services;

public class PaymentService : IPaymentService
{
    private readonly IRepository<Payment> repository;
    private readonly IRepository<Order> orderRepository;
    private readonly IMapper mapper;

    public PaymentService(IMapper mapper,IRepository<Payment> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<Payment> AddAsync(PaymentCreationDto paymentDto)
    {
        var order = await this.orderRepository
            .SelectAsync(order => order.Id == paymentDto.OrderId && 
            order.UserId == paymentDto.UserId);

        if (order is not null && order.isPaid is true)
            throw new CustomException(400, "Payment has been paid"); 
        else if (order is not null && order.isPaid is false)
        {
        var payment = this.mapper.Map<Payment>(paymentDto);
            order.isPaid = true;
        await this.repository.InsertAsync(payment);
        await this.repository.SaveAsync();
        return payment;
        }

        throw new CustomException(404, "order is not found");
    }

    public Task<bool> DelateAsync(Expression<Func<PaymentCreationDto, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Payment>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Payment> GetAsync(Expression<Func<PaymentCreationDto, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<Payment> UpdateAsync(Expression<Func<PaymentCreationDto, bool>> expression)
    {
        throw new NotImplementedException();
    }
}

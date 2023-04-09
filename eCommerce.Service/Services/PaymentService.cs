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
    private readonly IOrderService orderService;
    private readonly IMapper mapper;
    private readonly IUserService userService;

    public PaymentService(IMapper mapper,IRepository<Payment> 
        repository,IOrderService orderService,
        UserService userService)
    {
        this.mapper = mapper;
        this.orderService = orderService;
        this.repository = repository;
        this.userService = userService;
    }

    public async Task<Payment> AddAsync(PaymentCreationDto paymentDto)
    {
        var order = await this.orderService.GetAsync(order => order.Id == paymentDto.OrderId);

        var user = await this.userService.GetAsync(user => user.Id == paymentDto.UserId);

        if (order is not null && order.IsPaid is true)
            throw new CustomException(400, "Payment has been paid");

        if (user is null)
            throw new CustomException(400, "User Not Founf");


        else if (order is not null && order.IsPaid is false)
        {
            var payment = this.mapper.Map<Payment>(paymentDto);
            order.IsPaid = true;
            await this.repository.InsertAsync(payment);
            await this.repository.SaveAsync();
            return payment;
        }
        throw new CustomException(404, "order is not found"); ;
    }

    public async Task<bool> DelateAsync(Expression<Func<Payment, bool>> expression)
    {
        var isDeleted = await this.repository.DeleteAsync(expression);

        if (isDeleted == false)
            throw new CustomException(404, "Payment is not found");

        var res = await this.repository.DeleteAsync(expression);  
        await this.repository.SaveAsync();

        return res;
    }
    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        var payments =  this.repository.SelectAllAsync();
        if (payments.Any())
            throw new CustomException(404, "Payments is not found");

        return payments;
    }
    public async Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression)
    {
        var payment = await this.repository.SelectAsync(expression);
        if (payment == null)
            throw new CustomException(404, "Payment is not found");
        return payment;

    }
    public async Task<Payment> UpdateAsync(Expression<Func<Payment, bool>> expression,PaymentCreationDto dto)
    {
        var payment = await this.repository.SelectAsync(expression);
        if(payment is null)
            throw new CustomException(404, "Payments is not found");

        if (payment.OrderId != dto.OrderId)
            throw new CustomException(404, "Payments is not found");

        var result = this.mapper.Map<Payment>(dto);

        try
        {
            result.UpdatedAt = DateTime.UtcNow;
            await this.repository.UpdateAsync(result);
            await this.repository.SaveAsync();
            return result;
        }
        catch 
        {
            throw new CustomException(500, "Something Went Wrong");
        }

    }
}

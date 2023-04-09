using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Payments;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IPaymentService
{
	public Task<Payment> AddAsync(PaymentCreationDto paymentCreationDto);
	public Task<Payment> UpdateAsync(Expression<Func<PaymentCreationDto, bool>> expression);
	public Task<bool> DelateAsync(Expression<Func<PaymentCreationDto, bool>> expression);
	public Task<Payment> GetAsync(Expression<Func<PaymentCreationDto, bool>> expression);
	public Task<IQueryable<Payment>> GetAllAsync();


}

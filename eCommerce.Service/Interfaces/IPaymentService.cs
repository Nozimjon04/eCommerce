using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Payments;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IPaymentService
{
	public Task<Payment> AddAsync(PaymentCreationDto paymentCreationDto);
	public Task<Payment> UpdateAsync(Expression<Func<Payment, bool>> expression,PaymentCreationDto payment);
	public Task<bool> DelateAsync(Expression<Func<Payment, bool>> expression);
	public Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression);
	public Task<IQueryable<Payment>> GetAllAsync();


}

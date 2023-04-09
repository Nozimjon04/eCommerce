namespace eCommerce.Service.Exceptions;

public class CustomException:Exception
{
	public int Code;

	public CustomException(int code, string Massage):base(Massage)
	{
		Code = code;
	}
}

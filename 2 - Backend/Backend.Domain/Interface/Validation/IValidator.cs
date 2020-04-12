using Backend.Domain.Validation;

namespace Backend.Domain.Interfaces.Validation
{
  public interface IValidator<in TEntity>
	{
		ValidationResult Validate(TEntity entity);
	}
}

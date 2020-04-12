using Backend.Domain.Enum;
using Backend.Domain.Validation;

namespace Backend.Domain.Interfaces.Validation
{
  public interface IValidable
	{
		ValidationResult ValidationResult { get; }
    bool IsValid(CommandEnum.Type cmdType);
  }
}

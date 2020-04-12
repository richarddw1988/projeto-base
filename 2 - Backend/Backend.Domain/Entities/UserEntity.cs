using Backend.Domain.Enum;
using Backend.Domain.Interfaces.Validation;
using Backend.Domain.Models.Validators;
using Backend.Domain.Validation;

namespace Backend.Domain.Models
{
  public class UserEntity : Entity, IValidable
  {
    public string Name { get; set; }

    public string Cpf { get; set; }

    public ValidationResult ValidationResult { get; private set; }
    public bool IsValid(CommandEnum.Type cmdType)
    {
        ValidationResult = new UserValidator(cmdType).Validate(this);
        return ValidationResult.IsValid; 
    }
  }
}

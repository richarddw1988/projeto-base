using Backend.Domain.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Domain.Models.Specs.User
{
  public class CreateUserSpec : ISpecification<UserEntity>
  {
    public bool IsSatisfiedBy(UserEntity entity)
    {
      throw new NotImplementedException();
    }


  }
}

using Backend.Domain.Enum;
using Backend.Domain.Interface;
using Backend.Domain.Interfaces.Validation;
using Backend.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Backend.Domain.Services
{
  public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
  {
    private readonly IBaseRepository<TEntity> repository;

    public ValidationResult ValidationResult { get; private set; }

    public BaseService(IBaseRepository<TEntity> repository)
    {
      this.repository = repository;
      ValidationResult = new ValidationResult();
    }

    private ValidationResult Validate(TEntity obj, CommandEnum.Type cmdType)
    {
      if (!ValidationResult.IsValid)
        return ValidationResult;

      if (obj is IValidable)
      {
        var validable = obj as IValidable;

        if (!validable.IsValid(cmdType))
          ValidationResult = validable.ValidationResult;
      }

      return ValidationResult;
    }

    public virtual TEntity GetById(int id)
    {
      return repository.GetById(id);
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
      return repository.GetAll();
    }

    public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
    {
      return repository.Find(filter);
    }

    public virtual ValidationResult Add(TEntity obj)
    {
      if (Validate(obj, CommandEnum.Type.CREATE).IsValid)
      {
        repository.Add(obj);
      }

      return ValidationResult;
    }

    public virtual ValidationResult Update(int id,TEntity obj)
    {
      if (Validate(obj, CommandEnum.Type.UPDATE).IsValid)
      {
        repository.Update(id, obj);
      }

      return ValidationResult;
    }

    public virtual ValidationResult Remove(TEntity obj)
    {
      if (Validate(obj, CommandEnum.Type.DELETE).IsValid)
      {
        repository.Remove(obj);
      }

      return ValidationResult;
    }

    public virtual void SaveChanges()
    {
      repository.SaveChanges();
    }

    public virtual void Dispose()
    {
      repository.Dispose();
    }
  }
}

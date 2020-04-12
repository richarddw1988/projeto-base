﻿using Backend.Domain.Interfaces.Validation;
using Backend.Domain.Validation;
using System.Collections.Generic;

namespace TestePratico.Domain.Validation
{
  public class Validator<TEntity> : IValidator<TEntity>
	{
		protected readonly List<IValidationRule<TEntity>> rules;

		public Validator()
		{
			rules = new List<IValidationRule<TEntity>>();
		}

		protected virtual void AddRule(IValidationRule<TEntity> rule)
		{
			rules.Add(rule);
		}

		protected virtual void RemoveRule(IValidationRule<TEntity> rule)
		{
			rules.Remove(rule);
		}

		public ValidationResult Validate(TEntity entity)
		{
			var result = new ValidationResult();

			foreach (var rule in rules)
			{
				if (!rule.Valid(entity)) result.Add(rule.ErrorMessage);
			}

			return result;
		}
	}
}

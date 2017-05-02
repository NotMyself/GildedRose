using System.Collections.Generic;
using System.Text;

namespace GildedRose.Inventory.Domain.Entities.Validation
{
    /// <summary>
    /// Responsible for validating domain entities.
    /// </summary>
    /// <remarks>
    /// Note that validation is probably not required for this application given its current scope,
    /// but including it here as an example validation approach.
    /// 
    /// Also, a base class is not required since we currently only have a single entity we are
    /// validating, but again, just including as an example of validation approach.
    /// </remarks>
    public abstract class ValidatorBase<TEntity>
    {
        public ValidatorBase()
        : base()
        {
            ValidationErrors = new List<string>();
        }

        public List<string> ValidationErrors { get; set; }
        public string ValidationErrorSummary
        {
            get
            {
                StringBuilder sbErrorSummary = new StringBuilder();
                foreach (string error in ValidationErrors)
                {
                    sbErrorSummary.Append(" ");
                    sbErrorSummary.Append(error);
                }
                return sbErrorSummary.ToString();
            }
        }

        public void Validate(TEntity entity)
        {
            if (!IsValid(entity))
                throw new ValidationException(ValidationErrorSummary);
        }

        public abstract bool IsValid(TEntity entity);
    }
}

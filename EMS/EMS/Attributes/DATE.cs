using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMS.Attributes
{
    public class DATE : ValidationAttribute
    {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime dateValue)
                {
                    if (dateValue <= DateTime.Now)
                    {
                        return new ValidationResult("The Date must be in the future.");
                    }
                }
                return ValidationResult.Success;
            }
        }

    }

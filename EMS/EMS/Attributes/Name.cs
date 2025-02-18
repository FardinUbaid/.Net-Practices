using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMS.Attributes
{
    public class Name : ValidationAttribute
    {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string stringValue)
                {
                    if (string.IsNullOrEmpty(stringValue) )
                    {
                        return new ValidationResult("The Name field must not be null!");
                    }
                }
                return ValidationResult.Success;
            }
        }

    }

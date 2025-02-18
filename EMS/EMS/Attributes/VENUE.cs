using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMS.Attributes
{
    public class VENUE : ValidationAttribute
    {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string venueValue)
                {
                    if (venueValue.Length < 3)
                    {
                        return new ValidationResult("The Venue must be at least 3 characters long.");
                    }
                    if (!venueValue.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        return new ValidationResult("The Venue must contain only letters and spaces.");
                    }
                }
                return ValidationResult.Success;
            }
        }

    }

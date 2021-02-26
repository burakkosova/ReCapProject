﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.Id).Empty();

            RuleFor(c => c.ImagePath).NotEmpty();

            RuleFor(c => c.Date).NotEmpty();
        }
    }
}

using eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommercePrototype.Core.API.Infrastructor.Validatons.BasketLine
{

    public class PostBasketLineValidation : AbstractValidator<PostBasketLine>
    {
        public PostBasketLineValidation()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("Required_ProductId");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity_Cannot_Be_Less_Than_Or_Equal_To_0");
        }
    }
}

using eCommercePrototype.Common.Dto.MasterDto.Basket;
using eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine;
using eCommercePrototype.Common.Dto.Models;
using eCommercePrototype.Core.API.Controllers.Base;
using eCommercePrototype.Core.API.Infrastructor.Validatons.BasketLine;
using eCommercePrototype.Domain.Services.Basket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eCommercePrototype.Core.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BasketController : BaseApiController<BasketController>
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        /// <summary>
        /// Get basket and all lines in a shopping basket.
        /// </summary>
        [HttpGet]
        public async Task<WebApiResponse<GetBasket>> GetBasket()
        {
            WebApiResponse<GetBasket> webApiResponse = new WebApiResponse<GetBasket>();
            webApiResponse = await _basketService.GetBasketAsync(_workContext.CurrentCustomer.Id);
            return webApiResponse;
        }

        /// <summary>
        /// Add a product to a shopping basket
        /// </summary>
        [HttpPost("AddLineToBasket")]
        public async Task<WebApiResponse<GetBasketLine>> AddLineToBasket([FromBody] PostBasketLine request)
        {
            WebApiResponse<GetBasketLine> webApiResponse = new WebApiResponse<GetBasketLine>();

            PostBasketLineValidation validation = new PostBasketLineValidation();
            var validationResult = validation.Validate(request);
            if (validationResult.IsValid)
                webApiResponse = await _basketService.AddLineToBasketAsync(_workContext.CurrentCustomer.Id, request);
            else
            {
                webApiResponse.ResultMessage = string.Join(",", validationResult.Errors.Select(s => s.ErrorMessage).ToList());
                webApiResponse.IsSuccess = false;
            }
            return webApiResponse;
        }
    }
}

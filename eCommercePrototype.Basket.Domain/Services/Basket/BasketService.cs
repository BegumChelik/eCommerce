using AutoMapper;
using eCommercePrototype.Common.Dto.MasterDto.Basket;
using eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine;
using eCommercePrototype.Common.Dto.Models;
using eCommercePrototype.Domain.Repositories.Basket;
using eCommercePrototype.Domain.Repositories.Basket.BasketLine;
using eCommercePrototype.Domain.Repositories.Product.Stock;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using EF = eCommercePrototype.Common.Master.Entities;


namespace eCommercePrototype.Domain.Services.Basket
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketLineRepository _basketLineRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public BasketService(IBasketRepository basketRepository, IBasketLineRepository basketLineRepository, IStockRepository stockRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _basketLineRepository = basketLineRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<WebApiResponse<GetBasket>> GetBasketAsync(Guid customerId)
        {
            WebApiResponse<GetBasket> response = new WebApiResponse<GetBasket>();
            try
            {
                var basket = await _basketRepository.GetFromCustomerIdAsync(customerId);
                return new WebApiResponse<GetBasket>() { IsSuccess = true, ResultData = basket };

            }
            catch (Exception ex)
            {
                return new WebApiResponse<GetBasket>() { IsSuccess = false, ResultMessage = ex.Message };
            }
        }
        public async Task<WebApiResponse<GetBasketLine>> AddLineToBasketAsync(Guid customerId, PostBasketLine request)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    bool stockExist = false;

                    /// <summary>
                    /// check if the customer has a basket before
                    /// </summary>
                    var basket = await _basketRepository.GetFromCustomerIdAsync(customerId);
                    if (basket == null || basket.Id == Guid.Empty)
                    {
                        EF.Basket addBasket = new EF.Basket()
                        {
                            Id = Guid.NewGuid(),
                            CustomerId = customerId,
                        };
                        var resultBasketAdd = await _basketRepository.AddAsync(addBasket);

                        if (resultBasketAdd != null && resultBasketAdd.Id != Guid.Empty)
                            basket.Id = resultBasketAdd.Id;
                        else
                            return new WebApiResponse<GetBasketLine>() { IsSuccess = false, ResultMessage = "We_Are_Sorry_An_Unexpected_Error_Has_Ooccurred." };
                    }
                    else
                    {
                        /// <summary>
                        /// check if this product has been added before
                        /// </summary>
                        var existBasketLine = await _basketLineRepository.GetByProductIdAsync(basket.Id, request.ProductId);
                        if (existBasketLine != null && existBasketLine.Id != Guid.Empty)
                        {
                            existBasketLine.Quantity += request.Quantity;
                            stockExist = await _stockRepository.CheckStockAsync(existBasketLine.ProductId, existBasketLine.Quantity);
                            if (!stockExist)
                                return new WebApiResponse<GetBasketLine>() { IsSuccess = false, ResultMessage = "Not_Enough_Stock" };

                            var resultBasketLineUpdate = await _basketLineRepository.UpdateAsync(existBasketLine);
                            if (resultBasketLineUpdate != null && resultBasketLineUpdate.Id != Guid.Empty)
                            {
                                ts.Complete();
                                GetBasketLine getBasketLine = _mapper.Map<GetBasketLine>(resultBasketLineUpdate);
                                return new WebApiResponse<GetBasketLine>() { IsSuccess = true, ResultData = getBasketLine };
                            }
                            else
                                return new WebApiResponse<GetBasketLine>() { IsSuccess = false, ResultMessage = "We_Are_Sorry_An_Unexpected_Error_Has_Ooccurred." };
                        }
                    }

                    stockExist = await _stockRepository.CheckStockAsync(request.ProductId, request.Quantity);
                    if (!stockExist)
                        return new WebApiResponse<GetBasketLine>() { IsSuccess = false, ResultMessage = "Not_Enough_Stock" };

                    EF.BasketLine basketLine = new EF.BasketLine()
                    {
                        Id = new Guid(),
                        BasketId = basket.Id,
                        ProductId = request.ProductId,
                        Quantity = request.Quantity,
                        InsertDate = DateTime.Now
                    };
                    var resultBasketLineAdd = await _basketLineRepository.AddAsync(basketLine);
                    if (resultBasketLineAdd != null && resultBasketLineAdd.Id != Guid.Empty)
                    {
                        ts.Complete();
                        GetBasketLine getBasketLine = _mapper.Map<GetBasketLine>(resultBasketLineAdd);
                        return new WebApiResponse<GetBasketLine>() { IsSuccess = true, ResultData = getBasketLine };
                    }
                    return new WebApiResponse<GetBasketLine>() { IsSuccess = false, ResultMessage = "We_Are_Sorry_An_Unexpected_Error_Has_Ooccurred." };

                }
                catch (Exception ex)
                {
                    return new WebApiResponse<GetBasketLine>() { IsSuccess = false, ResultMessage = ex.Message };
                }
            }
        }

        public Task<GetBasket> ChangeQuantityAsync(int quantity)
        {
            ///TODO
            throw new NotImplementedException();
        }

        public Task<bool> EmptyBasket(string basketId)
        {  ///TODO
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Dto.Models
{
    public class WebApiResponse
    {
        public WebApiResponse()
        {

        }
        public WebApiResponse(string resultMessage, bool isSuccess)
        {
            ResultMessage = resultMessage;
            IsSuccess = isSuccess;
        }

        public long ElapsedMilliSeconds { get; set; }

        public string ResultMessage { get; set; }

        public bool IsSuccess { get; set; }

        public IEnumerable<string> ValidationErrors { get; set; }
    }

    public class WebApiResponse<T> : WebApiResponse
    {
        public WebApiResponse()
        {

        }

        public WebApiResponse(string v)
        {
        }

        public WebApiResponse(string resultMessage, bool isSuccess)
        {
            ResultMessage = resultMessage;
            IsSuccess = isSuccess;
        }

        public WebApiResponse(string resultMessage, bool isSuccess, T resultData)
        {
            ResultMessage = resultMessage;
            IsSuccess = isSuccess;
            ResultData = resultData;
        }

        public T ResultData { get; set; }
    }
}

using eCommercePrototype.Common.Dto.Client.WorkContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommercePrototype.Core.API.Controllers.Base
{
    [Authorize]
    [ApiController]
    public abstract class BaseApiController<T> : ControllerBase where T : BaseApiController<T>
    {
        public IWorkContext _workContext { get; set; }
        protected IWorkContext WorkContext => _workContext ?? (_workContext = HttpContext?.RequestServices.GetService<IWorkContext>());

        public BaseApiController()
        {

        }
    }
}

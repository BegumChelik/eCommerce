using eCommercePrototype.Common.Dto.Client.WorkContext;
using eCommercePrototype.Common.Dto.MasterDto.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommercePrototype.Core.API.Infrastructor.Context
{
    public class ApiWorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiWorkContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual GetCustomer CurrentCustomer
        {
            get
            {
                var authResult = _httpContextAccessor.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme).Result;
                if (!authResult.Succeeded)
                    return null;

                var userId = authResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                var firstName = authResult.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                var lastName = authResult.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname).Value;
                var email = authResult.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

                if (Guid.TryParse(userId, out Guid uid))
                {
                    var customer = new GetCustomer
                    {
                        Id = uid,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email
                    };
                    return customer;
                }
                return null;
            }
            set
            {
                CurrentCustomer = value;
            }
        }

    }
}

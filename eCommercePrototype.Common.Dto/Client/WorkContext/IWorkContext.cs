using eCommercePrototype.Common.Dto.MasterDto.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Dto.Client.WorkContext
{
    public interface IWorkContext
    {
        /// <summary>
        /// Gets the current customer
        /// </summary>
        GetCustomer CurrentCustomer { get; set; }
    }
}

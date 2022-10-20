using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCommercePrototype.Common.Dto.Enums
{
    public enum OrderStatusEnum
    {
        [Display(Name = "Hazırlanıyor")]
        Preparing = 1,

        [Display(Name = "Faturalandı")]
        Billed = 2,

        [Display(Name = "KargoyaVerildi")]
        Shipped = 3,

        [Display(Name = "TeslimEdildi")]
        Delivered = 4,

        [Display(Name = "İade")]
        Return = 5,

        [Display(Name = "İptal")]
        Cancel = 6,
    }
}

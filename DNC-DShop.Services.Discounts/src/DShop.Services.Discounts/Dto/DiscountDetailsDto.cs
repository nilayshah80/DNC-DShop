using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DShop.Services.Discounts.Dto
{
    public class DiscountDetailsDto
    {
        public CustomerDto Customer { get; set; }
        public DiscountDto Discount { get; set; }
    }
}

using DShop.Common.Types;
using DShop.Services.Discounts.Dto;
using System;
using System.Collections.Generic;

namespace DShop.Services.Discounts.Queries
{
    public class FindDiscounts : IQuery<IEnumerable<DiscountDto>>
    {
        public Guid CustomerId { get; set; }
    }
}

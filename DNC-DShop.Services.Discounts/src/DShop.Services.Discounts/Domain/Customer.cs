using DShop.Common.Types;
using System;

namespace DShop.Services.Discounts.Domain
{
    public class Customer : IIdentifiable
    {
        public Guid Id { get; private set; }
        
        public Customer(Guid id)
        {
            Id = id;
        }
    }
}

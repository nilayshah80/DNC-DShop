﻿using DShop.Common.Messages;
using Newtonsoft.Json;
using System;

namespace DShop.Services.Discounts.Messages.Events
{
    public class DiscountCreated :  IEvent
    {
        //Immutable
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public string Code { get; }
        public double Percentage { get; }

        [JsonConstructor]
        public DiscountCreated(Guid id, Guid customerId,
            string code, double percentage)
        {
            Id = id;
            CustomerId = customerId;
            Code = code;
            Percentage = percentage;
        }
    }
}

using DShop.Api.Messages.Commands.Discounts;
using DShop.Common.Mvc;
using DShop.Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System.Threading.Tasks;

namespace DShop.Api.Controllers
{
    [AllowAnonymous]
    public class DiscountsController : BaseController
    {
        public DiscountsController(IBusPublisher busPublisher, ITracer tracer) : base(busPublisher, tracer)
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDiscount command)
            => await SendAsync(command.BindId(c => c.Id), resourceId: command.Id,
                resource: "discounts");
    }
}

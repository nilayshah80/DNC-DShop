using DShop.Common.Dispatchers;
using DShop.Common.Mvc;
using DShop.Services.Discounts.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DShop.Services.Discounts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountsController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public DiscountsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDiscount command)
        {
            await _dispatcher.SendAsync(command.BindId(c => c.Id));

            return Accepted();
        }
    }
}
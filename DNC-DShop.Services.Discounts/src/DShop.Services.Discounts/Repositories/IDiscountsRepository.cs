using DShop.Services.Discounts.Domain;
using System.Threading.Tasks;

namespace DShop.Services.Discounts.Repositories
{
    public interface IDiscountsRepository
    {
        Task AddAsync(Discount discount);
        Task UpdateAsync(Discount discount);
    }
}

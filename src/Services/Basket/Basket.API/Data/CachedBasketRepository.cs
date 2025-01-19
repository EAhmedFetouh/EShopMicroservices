using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data;

public class CachedBasketRepository(IBasketRepository repo, IDistributedCache cache) : IBasketRepository
{
    public async Task<bool> DeleteBasket(string UserName, CancellationToken cancellationToken)
    {
        await repo.DeleteBasket(UserName, cancellationToken);
        await cache.RemoveAsync(UserName, cancellationToken);
        return true;
    }

    public async Task<ShoppingCart> GetBasket(string UserName, CancellationToken cancellationToken)
    {
        var cachedBasket = await cache.GetStringAsync(UserName, cancellationToken);
        if (!string.IsNullOrEmpty(cachedBasket))
            return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;

        var basket = await repo.GetBasket(UserName, cancellationToken);
        await cache.SetStringAsync(UserName, JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken)
    {
         await repo.StoreBasket(basket, cancellationToken);

         await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);

         return basket;
    }
}

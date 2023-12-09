using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Trolley.API.Entities;

namespace Trolley.API.Services
{
    public class MarketService : BaseService
    {

        public MarketService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }


        public async Task<List<Market>> GetMarketsAsync()
        {
            try
            {
                var markets = await _context.Markets.ToListAsync();
                return markets;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError($"Couldn't find markets", ex);
                throw new KeyNotFoundException("Couldn't find markets", ex);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Couldn't find markets", ex);
                throw new Exception("Couldn't find markets", ex);
            }
        }

        public async Task<List<string>> GetBlockedMarketsForUserAsync(string userId)
        {
            try
            {
                var blockedMarkets = await _context.BlockedMarkets
                    .Where(bm => bm.AppUserId == userId)
                    .Select(bm => bm.Market.Name)
                    .ToListAsync();

                return blockedMarkets;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't find blocked markets for user with id: {userId}", ex);
            }
        }

        public async Task BlockMarketAsync(string userId, int marketId)
        {
            try
            {
                var blockedMarket = new BlockedMarket
                {
                    AppUserId = userId,
                    MarketId = marketId
                };

                _context.BlockedMarkets.Add(blockedMarket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't block market with id: {marketId} for user with id: {userId}", ex);
            }
        }

        public async Task UnblockMarketAsync(string userId, int marketId)
        {
            try
            {
                var blockedMarket = await _context.BlockedMarkets
                    .FirstOrDefaultAsync(bm => bm.AppUserId == userId && bm.MarketId == marketId);

                _context.BlockedMarkets.Remove(blockedMarket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't unblock market with id: {marketId} for user with id: {userId}", ex);
            }
        }
    }
}

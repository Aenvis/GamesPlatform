using GamesPlatform.Infrastructure.DTOs;
using Microsoft.Extensions.Caching.Memory;

namespace GamesPlatform.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache memoryCache, Guid tokenId, JwtDto jwt)
        {
            memoryCache.Set(GetJwtKey(tokenId), jwt, TimeSpan.FromSeconds(5));
        }

        public static JwtDto? GetJwt(this IMemoryCache memoryCache, Guid tokenId) => memoryCache.Get<JwtDto>(GetJwtKey(tokenId));

        private static string GetJwtKey(Guid tokenId) => $"jwt-{tokenId}";
    }
}

using Microsoft.Extensions.Logging;

namespace WordLadder.Infrastructure.Repositories
{
    public class BaseRepository<T>
    {
        protected readonly ILogger<T> _logger;

        public BaseRepository(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}

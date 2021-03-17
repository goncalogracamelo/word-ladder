using WordLadder.Application.Configuration.Interfaces;

namespace WordLadder.Application.Configuration
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string AppName { get; set; }
    }
}

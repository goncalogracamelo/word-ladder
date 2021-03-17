using WordLadder.Application.Contracts;

namespace WordLadder.Application.Services.Interfaces
{
    public interface IMainService
    {
        void Run(MainServiceRequest mainServiceRequest);
    }
}
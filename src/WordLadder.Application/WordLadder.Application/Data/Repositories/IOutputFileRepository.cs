using WordLadder.Application.Domain.V1;

namespace WordLadder.Infrastructure.Repositories
{
    public interface IOutputFileRepository
    {
        void SaveWordLadder(WordPathV1 nodePath, string outputFile);
    }
}
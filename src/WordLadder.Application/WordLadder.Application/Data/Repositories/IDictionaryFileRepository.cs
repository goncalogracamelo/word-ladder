using WordLadder.Application.Domain.V1;

namespace WordLadder.Application.Data.Repositories
{
    public interface IDictionaryFileRepository
    {
        WordDictionaryV1 ReadDictionary(string inputFile);
    }
}
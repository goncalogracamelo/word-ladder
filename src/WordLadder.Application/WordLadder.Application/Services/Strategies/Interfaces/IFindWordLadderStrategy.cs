
using WordLadder.Application.Domain.V1;

namespace WordLadder.Application.Services.Strategies.Interfaces
{
    public interface IFindWordLadderStrategy
    {
        WordPathV1 RunSearch(WordDictionaryV1 wordDictionaryV1, WordV1 startWord, WordV1 endWord);
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WordLadder.Application.Domain.V1;

namespace WordLadder.Application.Services.Strategies
{
    public abstract class FindWordLadderBaseStrategy<T>
    {
        protected readonly ILogger<T> _logger;
        //protected readonly WordDictionaryV1 _wordDictionaryV1;
        public FindWordLadderBaseStrategy(ILogger<T> logger) //, WordDictionaryV1 wordDictionaryV1)
        {
            _logger = logger;
            //_wordDictionaryV1 = wordDictionaryV1;
        }

        protected bool EnsureSearchIsValid(WordDictionaryV1 wordDictionaryV1, WordV1 startWord, WordV1 endWord)
        {
            bool finalWordExists = wordDictionaryV1.WordExists(endWord);
            //TODO: check if the final word is in the dictionary, if not, return false
            return true;
        }
    }
}

using System;
using System.Collections.Generic;

namespace WordLadder.Application.Domain.V1
{
    public class WordDictionaryV1
    {
        private readonly List<WordV1> _words = new List<WordV1>();

        public WordDictionaryV1(List<string> words)
        {
            words.ForEach(wordText => _words.Add(new WordV1(wordText)));
        }


        public List<WordV1> FindAllWordsOneCharDifferent(WordV1 baseWord)
        {
            List<WordV1> result = new List<WordV1>();

            foreach (WordV1 word in _words)
            {
                if (word.IsOneCharDifference(baseWord))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        public bool WordExists(WordV1 endWord)
        {
            foreach (var word in _words)
            {
                if (word.Equals(endWord))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

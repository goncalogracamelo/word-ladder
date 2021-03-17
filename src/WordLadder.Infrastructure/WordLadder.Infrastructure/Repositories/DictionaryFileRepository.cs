using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using WordLadder.Application.Data.Repositories;
using WordLadder.Application.Domain.V1;

namespace WordLadder.Infrastructure.Repositories
{
    public class DictionaryFileRepository : IDictionaryFileRepository
    {
        private const int FixedWordLength = 4;
        public DictionaryFileRepository()
        {

        }

        public WordDictionaryV1 ReadDictionary(string inputFile)
        {
            var engine = new FileHelperEngine<WordInput>();

            var result = engine.ReadFile(inputFile);
                        
            List<string> words = new List<string>();

            foreach (var item in result)
            {
                if (item.WordText.Length == FixedWordLength)
                {
                    words.Add(item.WordText);
                }
            }

            WordDictionaryV1 dictionaryV1 = new WordDictionaryV1(words);

            return dictionaryV1;
        }
    }

    [DelimitedRecord(",")]
    public class WordInput
    {
        public string WordText;
    }
}

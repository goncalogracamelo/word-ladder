using System.Collections.Generic;
using WordLadder.Application.Domain.V1;
using Xunit;

namespace WordLadderUnitTests.Domain
{
    public class WordDictionaryUnitTest
    {
        private List<WordV1> GenerateWordList(string[] strs)
        {
            List<WordV1> result = new List<WordV1>();

            foreach (var str in strs)
            {
                result.Add(new WordV1(str));
            }

            return result;
        }

        [Theory]
        [InlineData("vide", true, new string[] { "hide", "wide", "side" })]
        [InlineData("more", true, new string[] { "sore" })]
        [InlineData("more", false, new string[] { "sort" })]
        [InlineData("some", true, new string[] { "sore" })]
        [InlineData("some", false, new string[] { "sort", "sore" })]
        public void IsOneCharDifference_Sucess(string inputBase, bool result, string[] expectedResult)
        {
            List<string> wordDict = new List<string> { "hide", "wide", "side", "hive", "sort", "sore" };

            WordV1 baseWord = new WordV1(inputBase);

            WordDictionaryV1 dict = new WordDictionaryV1(wordDict);

            List<WordV1> wordsOneCharDifferent = dict.FindAllWordsOneCharDifferent(baseWord);

            if (result)
            {
                Assert.Equal(wordsOneCharDifferent, GenerateWordList(expectedResult));
            }
            else
            {
                Assert.NotEqual(wordsOneCharDifferent, GenerateWordList(expectedResult));
            }

        }
    }
}

using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using WordLadder.Application.Domain.V1;
using WordLadder.Application.Services.Strategies;
using WordLadder.Application.Services.Strategies.Interfaces;
using Xunit;

namespace WordLadderUnitTests.Services
{
    public class FindWordLadderServiceUnitTests
    {

        private IFindWordLadderDeepFirstStrategy GenerateFindWordLadderService()
        {
            var loggerFindWordLadderDeepFirstStrategy = new Mock<ILogger<FindWordLadderDeepFirstStrategy>>();

            IFindWordLadderDeepFirstStrategy findWordLadderService =
                new FindWordLadderDeepFirstStrategy(loggerFindWordLadderDeepFirstStrategy.Object);

            return findWordLadderService;
        }

        private WordDictionaryV1 GenerateDictionary1()
        {
            List<string> wordDict =
                new List<string> { "hide", "wide", "side", "hive", "sort", "sore", "sate", "hate", "have", "hava", "sute", "sito", "haee" };

            return new WordDictionaryV1(wordDict);
        }


        [Theory]
        [InlineData("site", "wide")]
        [InlineData("mort", "sore")]
        [InlineData("site", "hava")]
        public void RunService_Sucess(string startStr, string endStr)
        {
            WordV1 startWord = new WordV1(startStr);
            WordV1 endWord = new WordV1(endStr);

            IFindWordLadderDeepFirstStrategy findWordLadderService = GenerateFindWordLadderService();
            WordDictionaryV1 wordDictionaryV1 = GenerateDictionary1();

            WordPathV1 nodePath = findWordLadderService.RunSearch(wordDictionaryV1, startWord, endWord);

            Assert.Equal(startWord, nodePath.GetFirstWord());

            Assert.Equal(endWord, nodePath.GetLastWord());

            //TODO: foreach word in the path, validate that the distance is only one char!
        }

    }
}

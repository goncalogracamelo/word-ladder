using WordLadder.Application.Domain.V1;
using Xunit;

namespace WordLadderUnitTests.Domain
{
    public class WordUnitTest
    {


        [Theory]
        [InlineData("hide", "hire", true)]
        [InlineData("hide", "hive", true)]
        [InlineData("hide", "side", true)]
        [InlineData("hide", "time", false)]
        [InlineData("hide", "tire", false)]
        public void IsOneCharDifference_Test(string inputBase, string inputCompareTo, bool expectedResult)
        {
            WordV1 baseWord = new WordV1(inputBase);

            WordV1 compareToWord = new WordV1(inputCompareTo);

            bool result = baseWord.IsOneCharDifference(compareToWord);

            Assert.Equal(result, expectedResult);
        }
    }
}

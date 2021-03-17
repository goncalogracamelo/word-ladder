using FileHelpers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WordLadder.Application.Domain.V1;

namespace WordLadder.Infrastructure.Repositories
{
    public class OutputFileRepository : BaseRepository<IOutputFileRepository>, IOutputFileRepository
    {
        public OutputFileRepository(ILogger<OutputFileRepository> logger) : base(logger)
        {
        }

        public void SaveWordLadder(WordPathV1 nodePath, string outputFile)
        {
            var engine = new FileHelperEngine<WordOutput>();

            List<string> resultPath = new List<string>();
            if (nodePath != null)
            {
                resultPath = nodePath.GetStringPath();
            }

            List<WordOutput> outputWords = new List<WordOutput>();
            
            resultPath.ForEach(wordText => outputWords.Add(new WordOutput { WordText = wordText }));
            
            engine.WriteFile(outputFile, outputWords);
        }
    }

    [DelimitedRecord("")]
    public class WordOutput
    {
        public string WordText;
    }
}

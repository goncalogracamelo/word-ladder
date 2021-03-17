using Microsoft.Extensions.Logging;
using WordLadder.Application.Configuration;
using WordLadder.Application.Configuration.Interfaces;
using WordLadder.Application.Contracts;
using WordLadder.Application.Data.Repositories;
using WordLadder.Application.Domain.V1;
using WordLadder.Application.Services.Interfaces;
using WordLadder.Application.Services.Strategies;
using WordLadder.Application.Services.Strategies.Interfaces;
using WordLadder.Infrastructure.Repositories;

namespace WordLadder.Application.Services
{
    public class MainService : IMainService
    {
        private readonly ILogger<IMainService> _logger;
        private readonly IDictionaryFileRepository _dictionaryFileRepository;
        private readonly IOutputFileRepository _outputFileRepository;
        private readonly IFindWordLadderDataFactory _findWordLadderDataFactory;

        public MainService(ILogger<IMainService> logger,
            IFindWordLadderDataFactory findWordLadderDataFactory,
            IDictionaryFileRepository dictionaryFileRepository,
            IOutputFileRepository outputFileRepository)
        {
            _logger = logger;
            _findWordLadderDataFactory = findWordLadderDataFactory;
            _dictionaryFileRepository = dictionaryFileRepository;
            _outputFileRepository = outputFileRepository;
        }

        public void Run(MainServiceRequest mainServiceRequest)
        {
            WordDictionaryV1 wordDictionaryV1 = _dictionaryFileRepository.ReadDictionary(mainServiceRequest.DictionaryFile);

            IFindWordLadderStrategy strategy = _findWordLadderDataFactory.GetStrategy(StrategyConstants.BreadthFirst_StrategyId);

            WordV1 startWord = new WordV1(mainServiceRequest.StartWord);
            WordV1 endWord = new WordV1(mainServiceRequest.EndWord);

            WordPathV1 nodePath = strategy.RunSearch(wordDictionaryV1, startWord, endWord);

            _outputFileRepository.SaveWordLadder(nodePath, mainServiceRequest.OutputFile);
        }
    }
}

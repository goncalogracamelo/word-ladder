using System;
using Microsoft.Extensions.DependencyInjection;
using WordLadder.Application.Configuration;
using WordLadder.Application.Services.Strategies.Interfaces;

namespace WordLadder.Application.Services.Strategies
{
    public class FindWordLadderDataFactory : IFindWordLadderDataFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public FindWordLadderDataFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IFindWordLadderStrategy GetStrategy(string strategyType)
        {
            IFindWordLadderStrategy strategy;

            switch (strategyType)
            {
                case StrategyConstants.BreadthFirst_StrategyId:
                    strategy = _serviceProvider.GetService<IFindWordLadderBreadthFirstStrategy>();
                    break;

                default:
                    strategy = _serviceProvider.GetService<IFindWordLadderDeepFirstStrategy>();
                    break;
            }

            return strategy;
        }
    }
}

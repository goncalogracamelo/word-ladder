using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WordLadder.Application.Domain.V1;
using WordLadder.Application.Services.Strategies.Interfaces;

namespace WordLadder.Application.Services.Strategies
{
    public class FindWordLadderDeepFirstStrategy : FindWordLadderBaseStrategy<FindWordLadderDeepFirstStrategy>, IFindWordLadderDeepFirstStrategy
    {
        public FindWordLadderDeepFirstStrategy(
            ILogger<FindWordLadderDeepFirstStrategy> logger) : base(logger)
        {
        }        
                
        public WordPathV1 RunSearch(WordDictionaryV1 wordDictionaryV1, WordV1 startWord, WordV1 endWord)
        {
            bool valid = EnsureSearchIsValid(wordDictionaryV1, startWord, endWord);

            if (!valid)
            {
                return null;
            }

            SolutionNodeV1 solutionNode = SearchLogic(wordDictionaryV1, startWord, endWord);

            if (solutionNode == null)
            {
                return null;
            }

            return solutionNode.NodePath;
        }

        private SolutionNodeV1 SearchLogic(WordDictionaryV1 wordDictionaryV1, WordV1 startWord, WordV1 endWord)
        {
            Stack<SolutionNodeV1> nodesContainer = new Stack<SolutionNodeV1>();
            SolutionNodeV1 solutionNode = null;

            SearchInitialization(nodesContainer, startWord, wordDictionaryV1);
           
            for (int numberOfIterations = 0; nodesContainer.Count > 0; numberOfIterations++)
            {
                SolutionNodeV1 nodeToProcess = nodesContainer.Pop();

                _logger.LogInformation("Iteration {Iteration}, Word {Word}, NodePath {NodePath}", numberOfIterations, nodeToProcess.GetWordText(), nodeToProcess.GetNodePath());

                if (nodeToProcess.IsSolution(endWord))
                {
                    solutionNode = nodeToProcess;
                    break;
                }

                List<SolutionNodeV1> childrenNodes = nodeToProcess.GenerateChildrenNodes();

                childrenNodes.ForEach(node => nodesContainer.Push(node));
            }

            return solutionNode;
        }



        private void SearchInitialization(
            Stack<SolutionNodeV1> nodesContainer,
            WordV1 startWord,
            WordDictionaryV1 wordDictionaryV1)
        {
            SolutionNodeV1 initialNode =
                new SolutionNodeV1(wordDictionaryV1, null, startWord);
            nodesContainer.Push(initialNode);
        }
    }
}

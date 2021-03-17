using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WordLadder.Application.Domain.V1;
using WordLadder.Application.Services.Strategies.Interfaces;

namespace WordLadder.Application.Services.Strategies
{
    public class FindWordLadderBreadthFirstStrategy : FindWordLadderBaseStrategy<FindWordLadderBreadthFirstStrategy>, IFindWordLadderBreadthFirstStrategy
    {
        public FindWordLadderBreadthFirstStrategy(
            ILogger<FindWordLadderBreadthFirstStrategy> logger) : base(logger)
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
            Queue<SolutionNodeV1> nodesQueue = new Queue<SolutionNodeV1>();
            SolutionNodeV1 solutionNode = null;

            SearchInitialization(nodesQueue, startWord, wordDictionaryV1);

            for (int numberOfIterations = 0; nodesQueue.Count > 0; numberOfIterations++)
            {
                SolutionNodeV1 nodeToProcess = nodesQueue.Dequeue();

                _logger.LogInformation("Iteration {Iteration}, Word {Word}, NodePath {NodePath}", numberOfIterations, nodeToProcess.GetWordText(), nodeToProcess.GetNodePath());

                if (nodeToProcess.IsSolution(endWord))
                {
                    solutionNode = nodeToProcess;
                    break;
                }

                List<SolutionNodeV1> childrenNodes = nodeToProcess.GenerateChildrenNodes();
                
                childrenNodes.ForEach(node => nodesQueue.Enqueue(node));
            }

            return solutionNode;
        }

       

        private void SearchInitialization(
            Queue<SolutionNodeV1> nodesQueue, 
            WordV1 startWord, 
            WordDictionaryV1 wordDictionaryV1)
        {
            SolutionNodeV1 initialNode = 
                new SolutionNodeV1(wordDictionaryV1, null, startWord);
            nodesQueue.Enqueue(initialNode);
        }
    }
}

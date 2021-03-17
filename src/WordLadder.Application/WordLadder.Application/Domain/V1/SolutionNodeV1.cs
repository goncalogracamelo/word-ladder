using System;
using System.Collections.Generic;

namespace WordLadder.Application.Domain.V1
{
    public class SolutionNodeV1
    {
        private readonly WordDictionaryV1 _wordDictionaryV1;

        private readonly WordV1 _nodeWord;

        public WordPathV1 NodePath { get; }

        public string GetWordText()
        {
            return _nodeWord.Text;
        }

        public SolutionNodeV1(WordDictionaryV1 wordDictionaryV1, WordPathV1 nodeBasePath, WordV1 nodeWord)
        {
            _wordDictionaryV1 = wordDictionaryV1;
            _nodeWord = nodeWord;
            NodePath = new WordPathV1(nodeBasePath, nodeWord);
        }        

        public List<SolutionNodeV1> GenerateChildrenNodes()
        {
            List<WordV1> allChildrenWords = _wordDictionaryV1.FindAllWordsOneCharDifferent(_nodeWord);

            List<SolutionNodeV1> result = new List<SolutionNodeV1>();

            //New list, by removing nodes already in the path
            foreach (var childrenWord in allChildrenWords)
            {
                if (!NodePath.ContainsWord(childrenWord))
                {
                    result.Add(new SolutionNodeV1(_wordDictionaryV1, NodePath, childrenWord));
                }
            }

            return result;
        }

        public bool IsSolution(WordV1 endWord)
        {
            return _nodeWord.Equals(endWord);
        }

        public string GetNodePath()
        {
            string nodePath = string.Empty;
            NodePath.GetStringPath().ForEach(wordText => nodePath += " > " + wordText);
            return nodePath;
        }

        //Note - strategies do not repeat states
        // - do not generate the state that we came from
        // - do not generate any state already in the path we are 
        // - do not generate any state globally already was generated

    }
}

using System.Collections.Generic;

namespace WordLadder.Application.Domain.V1
{
    public class WordPathV1
    {

        private readonly List<WordV1> _wordPath = new List<WordV1>();

        public WordPathV1(WordPathV1 basePath, WordV1 newNode)
        {
            if (basePath != null)
            {
                basePath._wordPath.ForEach(word => _wordPath.Add(word));
            }

            _wordPath.Add(newNode);
        }

        public WordV1 GetFirstWord()
        {
            return _wordPath[0];
        }

        public WordV1 GetLastWord()
        {
            return _wordPath[^1];
        }

        public int GetPathLength()
        {
            return _wordPath.Count;
        }

        public bool ContainsWord(WordV1 word)
        {
            bool bExists = false;

            foreach (var item in _wordPath)
            {
                if (item.Equals(word))
                {
                    bExists = true;
                    break;
                }
            }

            return bExists;
        }

        public List<string> GetStringPath()
        {
            List<string> result = new List<string>();
            _wordPath.ForEach(word => result.Add(word.Text));            
            return result;
        }
    }
}

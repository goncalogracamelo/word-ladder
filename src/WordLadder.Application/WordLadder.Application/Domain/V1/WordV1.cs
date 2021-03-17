namespace WordLadder.Application.Domain.V1
{
    public class WordV1
    {
        public WordV1(string v)
        {
            Text = v;
        }

        public string Text { get; }

        public bool IsOneCharDifference(WordV1 word)
        {
            int differences = 0;
            char[] baseWordChars = Text.ToCharArray();
            char[] compareToWordChars = word.Text.ToCharArray();

            for (int i = 0; i < baseWordChars.Length; i++)
            {
                if (baseWordChars[i] != compareToWordChars[i])
                {
                    differences++;
                }
                if (differences > 1)
                {
                    return false;
                }
            }

            return true;
        }

        public int WordDistance(WordV1 endWord)
        {
            int differences = 0;
            char[] baseWordChars = Text.ToCharArray();
            char[] endWordChars = endWord.Text.ToCharArray();

            for (int i = 0; i < baseWordChars.Length; i++)
            {
                if (baseWordChars[i] != endWordChars[i])
                {
                    differences++;
                }
            }

            return differences;
        }

        public bool Equals(WordV1 w)
        {
            if (w.Text.Equals(Text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as WordV1);
        }
    }
}

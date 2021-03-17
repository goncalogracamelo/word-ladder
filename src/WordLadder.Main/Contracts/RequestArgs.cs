

namespace WordLadderApp.Contracts
{
    public class RequestArgs
    {
        public string StartWord { get; set; }

        public string EndWord { get; set; }

        public string DictionaryFile { get; set; }

        public string OutputFile { get; set; }

    }
}

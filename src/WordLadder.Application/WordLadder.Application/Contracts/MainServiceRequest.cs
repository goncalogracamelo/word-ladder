namespace WordLadder.Application.Contracts
{
    public class MainServiceRequest
    {
        public string StartWord { get; set; }

        public string EndWord { get; set; }

        public string DictionaryFile { get; set; }

        public string OutputFile { get; set; }
    }
}

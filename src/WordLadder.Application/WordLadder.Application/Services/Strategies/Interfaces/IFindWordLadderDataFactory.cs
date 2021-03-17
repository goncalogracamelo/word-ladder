namespace WordLadder.Application.Services.Strategies.Interfaces
{
    public interface IFindWordLadderDataFactory
    {
        IFindWordLadderStrategy GetStrategy(string strategyType);
    }
}
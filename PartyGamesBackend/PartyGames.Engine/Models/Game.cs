using PartyGames.Engine.Services.GameServices;
using static PartyGames.Engine.Enums.GameEnum;

namespace PartyGames.Engine.Models
{
    public class Game : IGame
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IGameService _gameService;


        private List<Player> Players { get; set; } = new List<Player>();

        private Round? Round { get; set; }
        private List<Answer> RoundAnswers { get; set; } = new List<Answer>();
        private List<Result> Results { get; set; } = new List<Result>();

        private GameStates GameState { get; set; } = GameStates.Prepare;

        private readonly PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(1000));
        private readonly CancellationToken _timerCancel = new CancellationToken();



        public Game(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            _gameService = new GameSolveEquationService();
        }

        public List<Player> GetPlayers()
        {
            return Players.ToList();
        }

        public void AddPlayer(Player player)
        {
            if (Players.Contains(player))
            {
                throw new ArgumentException("The game already contains this player");
            }

            Players.Add(player);
        }

        public void Start()
        {
            if (GameState != GameStates.Prepare)
            {
                throw new InvalidOperationException("Game already started");
            }

            NextRound();
        }

        private void NextRound()
        {
            RoundAnswers.Clear();
            Round = _gameService.GenerateNextRound();
            GameState = GameStates.Play;
        }

        private void EvaluateRound()
        {
            GameState = GameStates.RoundEvaluation;

            var playersToSolve = Players.ToList();
            var correctAnswersToSolve = RoundAnswers.Where(x => x.IsCorrect).ToList();

            var pointsToGive = Players.Count - 1;

            var roundResults = new List<Result>();

            while (correctAnswersToSolve.Count > 0)
            {
                var answer = correctAnswersToSolve.First();
                roundResults.Add(
                    new Result(
                        answer.Player,
                        pointsToGive
                        )
                    );
                correctAnswersToSolve.Remove(answer);
                playersToSolve.Remove(answer.Player);

                pointsToGive--;
            }

            while (playersToSolve.Count > 0)
            {
                var player = playersToSolve.First();
                roundResults.Add(
                    new Result(
                        player,
                        0
                        )
                    );
            }

            roundResults.Reverse();
            roundResults.ForEach(x => Results.Prepend(x));


        }

        private void Finish()
        {
            GameState = GameStates.Finish;
        }

        public void SelectOption(Player player, int optionIndex)
        {
            if (GameState == GameStates.Play)
            {
                throw new InvalidOperationException("Game is not in 'Play' state");
            }

            if (Round!.Options.Count - 1 < optionIndex)
            {
                throw new ArgumentException("Option index is out of range");
            }

            if (RoundAnswers.Any(x => x.Player == player))
            {
                throw new InvalidOperationException("You already answered");
            }

            var option = Round!.Options[optionIndex];

            RoundAnswers.Add(new Answer(
                player,
                option,
                DateTime.Now
                ));
        }
    }
}

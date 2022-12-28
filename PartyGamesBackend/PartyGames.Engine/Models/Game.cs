﻿using PartyGames.Engine.Services.GameServices;
using System.Threading;
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
        private List<Result> LastResults { get; set; } = new List<Result>();

        private GameStates GameState { get; set; } = GameStates.Prepare;

        private readonly PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(1000));
        private readonly CancellationTokenSource _timerCancelSource;
        private readonly CancellationToken _timerCancel;

        private DateTime LastActionDate { get; set; } = DateTime.Now;

        public Game(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            _gameService = new GameSolveEquationService();

            _timerCancelSource = new CancellationTokenSource();
            _timerCancel = _timerCancelSource.Token;
        }

        public List<Player> GetPlayers()
        {
            return Players.OrderByDescending(x=>x.Points).ToList();
        }

        public void AddPlayer(Player player)
        {
            if (Players.Contains(player))
            {
                return;
                //throw new ArgumentException("The game already contains this player");
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
            RunInfiniteClock();

        }

        private void Finish()
        {
            GameState = GameStates.Finish;
            _timerCancelSource.Cancel();
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

                answer.Player.Points+= pointsToGive;


                pointsToGive--;
            }

            while (playersToSolve.Count > 0)
            {
                var player = playersToSolve.First();
                roundResults.Add(
                    new Result(
                        player,
                        null
                        )
                    );

                playersToSolve.Remove(player);
            }

            LastResults.Clear();
            LastResults.AddRange(roundResults);

            Results.AddRange(roundResults);

            Round.Options.First(x=>x.IsCorrect).PublicIsCorrect= true;
        }

        private void NextRound()
        {
            RoundAnswers.Clear();
            Round = _gameService.GenerateNextRound();
            GameState = GameStates.Play;
        }

        private void RunInfiniteClock()
        {
            _ = Task.Run(async () =>
            {
                while (await _timer.WaitForNextTickAsync(_timerCancel) && !_timerCancel.IsCancellationRequested)
                {
                    if (DateTime.Now - LastActionDate > TimeSpan.FromMinutes(10))
                    {
                        Finish();
                    }

                    if (GameState == GameStates.Play)
                    {
                        if(Round!.EndTime < DateTime.Now)
                        {
                            EvaluateRound();
                            continue;
                        }
                    }

                    if(GameState == GameStates.RoundEvaluation)
                    {
                        if(DateTime.Now - Round!.EndTime > TimeSpan.FromSeconds(5))
                        {
                            NextRound();
                            continue;
                        }
                    }

                    if(GameState == GameStates.Finish)
                    {
                        return;
                    }

                    
                }

                return;
            });
        }


        

        public void SelectOption(Player player, int optionIndex)
        {
            this.LastActionDate = DateTime.Now;

            if (GameState != GameStates.Play)
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
                option.IsCorrect,
                option,
                DateTime.Now
                ));
        }

        public Round? GetRound()
        {
            return Round;
        }

        public GameStates GetGameState()
        {
            return GameState;
        }

        public List<Result> GetResults()
        {
            var resList = new List<Result>();
            foreach(var player in Players)
            {
                resList.Add(new Result(
                    player,
                    Results.Where(x=>x.Player == player).Sum(x=>x.Points)
                    ));
            }

            resList = resList.OrderByDescending(x=>x.Points).ToList();

            return resList.ToList();
        }

        public List<Result> GetLastResults()
        {
            return LastResults.ToList();
        }

    }
}

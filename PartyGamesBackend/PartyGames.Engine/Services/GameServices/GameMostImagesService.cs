using PartyGames.Engine.Extensions;
using PartyGames.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Services.GameServices
{
    internal class GameMostImagesService : IGameService
    {
        Random _random = new Random();
        private const int _uniqueImagesCount = 10;
        private const int _optionsCount = 25;
        private int _offsetId = 0;

        public Round GenerateNextRound()
        {
            SetNewIdOffset();

            var options = new List<RoundOption>();

            options.AddRange(
                GenerateIdenticalOptions(2)
                );

            options.AddRange(
                GenerateRandomOptions(_optionsCount - 2)
                );

            MakeOneImageDominant_And_SetIsCorrect(options);

            options.Shuffle();

            var title = new RoundTitle("Select the most frequently occurring image");


            return new Round(
                title,
                options,
                DateTime.Now,
                DateTime.Now.AddSeconds(10)
                );
        }

        private List<RoundOption> GenerateIdenticalOptions(int number)
        {
            var res = new List<RoundOption>();

            var id = GenerateRandomId();
            var url = GetImageUrl(id);

            for (int i = 0; i < number; i++)
            {
                res.Add(
                new RoundOption(url, false)
                );
            }

            return res;
        }

        private List<RoundOption> GenerateRandomOptions(int number)
        {
            var res = new List<RoundOption>();

            for (int i = 0; i < number; i++)
            {
                var randId = GenerateRandomId();
                var imgUrl = GetImageUrl(randId);

                res.Add(
                    new RoundOption(
                            imgUrl,
                            false
                        )
                    );
            }

            return res;
        }

        private void MakeOneImageDominant_And_SetIsCorrect(List<RoundOption> options)
        {
            var maxCountOfAnyImage = GetMaxCountOfAnyImage(options);

            var groupedImages = options.GroupBy(x => x.Text);

            var listOfGroupedImagesWithMostOccurences = groupedImages.Where(x=>x.ToList().Count == maxCountOfAnyImage).ToList();

            var correctUrl = listOfGroupedImagesWithMostOccurences[0].ToList().First().Text;

            if (listOfGroupedImagesWithMostOccurences.Count > 1)
            {
                // Change 1 image from second group to correct image -> first group will have the most correct images
                listOfGroupedImagesWithMostOccurences[1].ToList()[0].Text = correctUrl;
            }

            

            

            options.ForEach(x=>x.IsCorrect = x.Text == correctUrl);
        }

        private int GetMaxCountOfAnyImage(List<RoundOption> options)
        {
            var max = 0;

            options.ForEach(x => 
                max = Math.Max(
                    max, 
                    options.Count(y => y.Text == x.Text)
                    )
            );

            return max;
        }

        private string GetImageUrl(int id)
        {
            return $"https://www.gravatar.com/avatar/{id}?d=identicon&f=y";
        }

        private int GenerateRandomId()
        {
            return _random.Next() % _uniqueImagesCount + _offsetId;
        }

        private void SetNewIdOffset()
        {
            _offsetId = _random.Next() % 1000;
        }
    }
}

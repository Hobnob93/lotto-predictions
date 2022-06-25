﻿using LottoPredictions.Core.Enums;
using LottoPredictions.Core.Interfaces;
using LottoPredictions.Core.Models;

namespace LottoPredictions.Core.Services
{
    public class Service : IService
    {
        private readonly IBallSetFactory _ballSetFactory;

        public Service(IBallSetFactory ballSetFactory)
        {
            _ballSetFactory = ballSetFactory;
        }


        public void Run()
        {
            var firstBallSet = RequestBallSet("\nPlease provide the 1st list of normal balls.", BallSetType.Normal);
            var secondBallSet = RequestBallSet("\nPlease provide the 2nd list of normal balls.", BallSetType.Normal);
            var thunderballs = RequestBallSet("\nPlease provide the list of thunderballs.", BallSetType.Thunderball);
        }

        private BallSet RequestBallSet(string message, BallSetType ballSetType)
        {
            var ballSet = _ballSetFactory.Empty;
            bool isValid;

            do
            {
                Console.WriteLine(message);
                var rawBalls = GetBallSetInput();
                (isValid, ballSet) = _ballSetFactory.FromInput(ballSetType, rawBalls);
            }
            while (!isValid);

            Console.WriteLine(ballSet.ToString());

            return ballSet;
        }

        private string GetBallSetInput()
        {
            string? input;

            do
            {
                Console.Write("Balls: ");
                input = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(input));

            return input;
        }
    }
}

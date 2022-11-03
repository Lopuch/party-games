using NCalc;
using PartyGames.Engine.Enums;
using PartyGames.Engine.Extensions;
using PartyGames.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PartyGames.Engine.Enums.SolveEquationEnums;

namespace PartyGames.Engine.Services.GameServices
{
    internal class GameSolveEquationService : IGameService
    {
        Random _random = new Random();



        public GameSolveEquationService()
        {
            
        }

        public Round GenerateNextRound()
        {
            var optionsCount = 4;

            var options = new List<RoundOption>();

            for(int i= 0; i < optionsCount; i++)
            {
                var isCorrect = i == 0;

                options.Add(
                    GenerateUniqueOption(options, isCorrect)
                    );
            }

            options.Shuffle();

            var title = new RoundTitle(options.First(x => x.IsCorrect).Text);

            options.ForEach(x => x.Text = Solve(x.Text).ToString());

            return new Round(
                title,
                options,
                DateTime.Now,
                DateTime.Now.AddSeconds(10)
                );

        }

        private RoundOption GenerateUniqueOption(List<RoundOption> options, bool isCorrect)
        {
            while (true)
            {
                var operands = GenerateOperands(3, 10);
                var operators = GenerateOperators(3);
                var equationString = GetStringEquation(operands, operators);
                var option = new RoundOption(
                    equationString,
                    isCorrect
                    );

                if (!options.Any(x => x.Text == equationString))
                {
                    return option;
                }
            }
        }

        internal List<int> GenerateOperands(int count, int minAndMaxValue)
        {
            if(count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be greater than ZERO");
            }

            var res = new List<int>();


            for(int i = 0; i < count; i++)
            {
                int number;

                while ((number = _random.Next(-minAndMaxValue, minAndMaxValue)) == 0) ;

                res.Add(number);
            }

            return res;

        }

        internal List<Operator> GenerateOperators(int numbersCount)
        {
            if(numbersCount <= 1)
            {
                throw new ArgumentOutOfRangeException("NumbersCount must be greater than one");
            }

            var res = new List<Operator>();

            for(int i=0; i < numbersCount - 1; i++)
            {
                res.Add(GenerateOperator());
            }

            return res;
        }

        internal Operator GenerateOperator()
        {
            var rand = _random.Next(0, 100);

            if(rand < 30)
            {
                return Operator.Add;
            }

            if(rand < 60)
            {
                return Operator.Substract;
            }

            if(rand < 80)
            {
                return Operator.Multiply;
            }

            return Operator.Divide;
        }

        internal double Solve(string expression)
        {
            Expression e = new Expression(expression);
            var result = e.Evaluate();

            return Convert.ToDouble(result);
        }


        private string GetStringEquation(List<int> operands, List<Operator> operators)
        {
            if(operators.Count != operands.Count-1)
            {
                throw new ArgumentException("Number of operators must be smaller by 1 to operands");
            }

            if(operands.Count < 2)
            {
                throw new ArgumentOutOfRangeException("Number of operands must be equal or greater than 2");
            }

            List<string> parts = new List<string>();

            int i = 0;

            while(true)
            {
                parts.Add(operands[i].ToString());
                if(operands.Count-1 == i)
                {
                    break;
                }

                parts.Add( OperatorToString(operators[i]));
                i++;
            }

            return string.Join(" ", parts);
        }

        internal string OperatorToString(Operator @operator)
        {
            switch(@operator)
            {
                case Operator.Add:
                    return "+";
                case Operator.Substract:
                    return "-";
                case Operator.Multiply:
                    return "*";
                case Operator.Divide:
                    return "/";
            }

            throw new ArgumentException("Unknown operator");
        }
    }
}

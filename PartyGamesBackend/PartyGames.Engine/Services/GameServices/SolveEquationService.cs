using NCalc;
using PartyGames.Engine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PartyGames.Engine.Enums.SolveEquationEnums;

namespace PartyGames.Engine.Services.GameServices
{
    internal class SolveEquationService
    {
        Random _random = new Random();

        public SolveEquationService()
        {

        }

        public List<int> GenerateOperands(int count, int minAndMaxValue)
        {
            if(count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be greater than ZERO");
            }

            var res = new List<int>();


            for(int i = 0; i < count; i++)
            {
                res.Add(_random.Next(minAndMaxValue, minAndMaxValue));
            }

            return res;

        }

        public List<Operator> GenerateOperators(int nubmersCount)
        {
            if(nubmersCount <= 1)
            {
                throw new ArgumentOutOfRangeException("NumbersCount must be greater than one");
            }

            var res = new List<Operator>();

            for(int i=0; i < nubmersCount -1; i++)
            {
                res.Add(GenerateOperator());
            }

            return res;
        }

        public Operator GenerateOperator()
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

        public double Solve(List<int> operands, List<Operator> operators)
        {
            var expression = GetStringEquation(operands, operators);

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

        public string OperatorToString(Operator @operator)
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

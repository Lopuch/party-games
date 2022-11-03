using FluentAssertions;
using PartyGames.Engine.Services.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PartyGames.Engine.Enums.SolveEquationEnums;

namespace Engine.Tests.Unit
{
    public class SolveEquationServiceTests
    {
        private readonly GameSolveEquationService _sut;

        public SolveEquationServiceTests()
        {
            _sut = new GameSolveEquationService();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public void GenerateOperands_ShouldRetunCorrectNumberOfOperands_WhenCorrectCountIsProvided(
            int count
            )
        {
            var result = _sut.GenerateOperands(count, 1000);

            result.Count.Should().Be(count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GenerateOperands_ShouldThrowException_WhenCountIsLessOrEqualThanZero(
            int count)
        {
            Action result = () => _sut.GenerateOperands(count, 1000);

            result.Should()
                .ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void GenerateOperators_ShouldThrowException_WhenNumberCountIsLessThenTwo(
            int numbersCount)
        {
            Action result = () => _sut.GenerateOperators(numbersCount);

            result.Should()
                .ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(10, 9)]
        public void GenerateOperators_ShouldReturnNMinusOneOpetors_WhenNNumbersCountIsProvided(
            int numbersCount, int expected)
        {
            var result = _sut.GenerateOperators(numbersCount);

            result.Count.Should().Be(expected);
        }

        //[Theory]
        //[MemberData(nameof(Solve_Data))]
        //public void Solve_ShouldReturnCorrectResult_WhenInputsAreCorrect(
        //    List<int> operands,
        //    List<Operator> operators,
        //    double expected)
        //{
        //    var result = _sut.Solve(operands, operators);

        //    result.Should().BeApproximately(expected, 0.001);
        //}


        //public static IEnumerable<object[]> Solve_Data()
        //{
        //    yield return new object[] { new List<int> { 1, 1}, new List<Operator> { Operator.Add }, 2d };
        //    yield return new object[] { new List<int> { -1, -1 }, new List<Operator> { Operator.Add }, -2d };
        //    yield return new object[] { new List<int> { 1, 2, 3, 4, 5 }, new List<Operator> { 
        //        Operator.Add, 
        //        Operator.Substract,
        //        Operator.Multiply,
        //        Operator.Divide
        //    }, 0.6d };
        //}
    }
}

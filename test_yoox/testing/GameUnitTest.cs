using NUnit.Framework;
using FluentAssertions;
using software;

namespace testing
{
    [TestFixture]
    public class GameUnitTest
    {
        private Game sut;

        [SetUp]
        public void Setup()
        {
            sut = new Game();
        }

        [Test]
        public void Game_isWonByPlayer1_whenPlayer2TwoPoints_And_Player1FourPoints()
        {
            sut.AddPointToPlayer2();
            sut.AddPointToPlayer2();

            sut.AddPointToPlayer1();
            sut.AddPointToPlayer1();
            sut.AddPointToPlayer1();
            sut.AddPointToPlayer1();

            var score = sut.GetScore();

            score.player1.Should().NotBe(Scores.Forty);
            score.player2.Should().Be(Scores.Thirty);

            sut.GetWinner().Should().Be(Winners.Player1);
        }

        [Test]
        public void Game_isWonByPlayer1_whenPlayer2ThreePoints_And_Player1FivePoints()
        {
            sut.AddPointToPlayer2();
            sut.AddPointToPlayer2();
            sut.AddPointToPlayer2();

            sut.AddPointToPlayer1();
            sut.AddPointToPlayer1();
            sut.AddPointToPlayer1();
            sut.AddPointToPlayer1();
            sut.AddPointToPlayer1();

            var score = sut.GetScore();

            score.player1.Should().Be(Scores.Advantage);
            score.player2.Should().BeNull();

            sut.GetWinner().Should().Be(Winners.Player1);
        }

        [Test]
        public void ScoreProgression_isLoveFifteenThirtyForty_WhenPlayerPointsZeroToThree()
        {
            var score = sut.GetScore();
            score.player1.Should().Be(Scores.Love);

            sut.AddPointToPlayer1();

            score = sut.GetScore();
            score.player1.Should().Be(Scores.Fifteen);

            sut.AddPointToPlayer1();

            score = sut.GetScore();
            score.player1.Should().Be(Scores.Thirty);

            sut.AddPointToPlayer1();

            score = sut.GetScore();
            score.player1.Should().Be(Scores.Forty);
        }

        [Test]
        public void Score_isDeuce_whenPointsEquals_And_AtLeast3Both_And_ScoredAlternate()
        {
            var score = sut.GetScore();
            score.player1.Should().NotBe(Scores.Deuce);
            score.player2.Should().NotBe(Scores.Deuce);

            sut.AddPointToPlayer1();
            sut.AddPointToPlayer2();
            score = sut.GetScore();
            score.player1.Should().NotBe(Scores.Deuce);
            score.player2.Should().NotBe(Scores.Deuce);

            sut.AddPointToPlayer1();
            sut.AddPointToPlayer2();
            score = sut.GetScore();
            score.player1.Should().NotBe(Scores.Deuce);
            score.player2.Should().NotBe(Scores.Deuce);

            sut.AddPointToPlayer1();
            sut.AddPointToPlayer2();
            score = sut.GetScore();
            score.player1.Should().Be(Scores.Deuce);
            score.player2.Should().Be(Scores.Deuce);

            sut.AddPointToPlayer1();
            sut.AddPointToPlayer2();
            score = sut.GetScore();
            score.player1.Should().Be(Scores.Deuce);
            score.player2.Should().Be(Scores.Deuce);

            sut.AddPointToPlayer1();
            sut.AddPointToPlayer2();
            score = sut.GetScore();
            score.player1.Should().Be(Scores.Deuce);
            score.player2.Should().Be(Scores.Deuce);
        }

        [Test]
        public void ScoreOfPlayer_isAdvantage_whenPlayerOnePointMoreThanOpponent_And_BothPlayersAtLeastThreePoints()
        {
            sut.AddPointToPlayer2();
            sut.AddPointToPlayer2();
            sut.AddPointToPlayer2();

            sut.AddPointToPlayer1();
            sut.AddPointToPlayer1();
            sut.AddPointToPlayer1();

            sut.AddPointToPlayer1();
            
            var score = sut.GetScore();
            score.player1.Should().Be(Scores.Advantage);
            score.player2.Should().BeNull();

            sut.AddPointToPlayer2();
            sut.AddPointToPlayer2();


            score = sut.GetScore();
            score.player1.Should().BeNull();
            score.player2.Should().Be(Scores.Advantage);
        }        
    }
}
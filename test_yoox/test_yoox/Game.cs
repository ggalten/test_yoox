// See https://aka.ms/new-console-template for more information
namespace software
{
    public class Game
    {
        private int pointsPlayer1 { get; set; } = 0;
        private int pointsPlayer2 { get; set; } = 0;
        public bool gameIsOver { get; private set; } = false;
        private Winners winner;


        public void AddPointToPlayer1()
        {
            if (!gameIsOver)
            {
                pointsPlayer1++;
                UpdateGameIsOver();
            }
        }

        public void AddPointToPlayer2()
        {
            if (!gameIsOver)
            {
                pointsPlayer2++;
                UpdateGameIsOver();
            }
        }

        private void UpdateGameIsOver()
        {
            gameIsOver = (pointsPlayer1 >= 4 || pointsPlayer2 >= 4) && Math.Abs(pointsPlayer1 - pointsPlayer2) > 1;

            if (gameIsOver)
            {
                if (pointsPlayer1 > pointsPlayer2)
                {
                    winner = Winners.Player1;
                }
                else
                {
                    winner = Winners.Player2;
                }
            }
        }

        public (Scores? player1, Scores? player2) GetScore()
        {

            if (pointsPlayer1 < 3 || pointsPlayer2 < 3)
            {
                return (player1: (Scores)pointsPlayer1, player2: (Scores)pointsPlayer2);
            }
            else if (pointsPlayer1 == pointsPlayer2)
            {
                return (player1: Scores.Deuce, player2: Scores.Deuce);
            }
            else if (pointsPlayer1 > pointsPlayer2)
            {
                return (player1: Scores.Advantage, player2: null);
            }
            return (player1: null, player2: Scores.Advantage);

        }

        public Winners? GetWinner()
        {
            if (gameIsOver)
            {
                return winner;
            }
            return null;
        }
    }
}
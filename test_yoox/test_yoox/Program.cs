// See https://aka.ms/new-console-template for more information

using software;

Game game = new Game();

game.AddPointToPlayer1();
game.AddPointToPlayer1();
var currentScore = game.GetScore();
Console.WriteLine($"punteggio p1: {currentScore.player1} p2: {currentScore.player2}");

game.AddPointToPlayer1();
game.AddPointToPlayer1();

Console.WriteLine($"Vincitore è: {game.winner}");
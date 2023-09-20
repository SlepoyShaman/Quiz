using ConsoleApp1.Configuration;
using ConsoleApp1.Game;
using ConsoleApp1.Storage;

var configuration = new JsonConfiguration("..\\..\\..\\Configuration\\config.json");
var storage = new GameInfoStorage();

Console.WriteLine("-сыграть в КВИЗ - Y\r\n-просмотреть прошлые результаты - R\r\n-выйти N\r\n");
var choice = Console.ReadLine().ToLower();

switch (choice)
{
    case "y":
        {
            var game = new Game(configuration, storage);
            await game.StartGame();
            break;
        }
    case "r":
        {
            var bestGames = await storage.LoadBestGamesInfo();
            foreach (var game in bestGames)
            {
                Console.WriteLine(game.ToString());
            }
            break;
        }
    case "n":
        {
            break;
        }
}


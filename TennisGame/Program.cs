// See https://aka.ms/new-console-template for more information

// vars declair
using TennisGame;
using System.Threading;
using System.Runtime.CompilerServices;
using TennisGame;
using TennisGame.Model;

string result = "";
string name;
string surname;
string parse;
int level;
bool samePlayer;

while(true)
{
    Console.Clear();
    samePlayer = true;

    Console.WriteLine("\tTENNIS GAME SIMULATOR\n");

    // insert player 1
    Console.WriteLine("\tPlayer1");
    Console.Write("Name: ");
    name = Console.ReadLine();
    Console.Write("SurName: ");
    surname = Console.ReadLine();
    Console.Write("Level (1-10): ");
    parse = Console.ReadLine();
    while (!Int32.TryParse(parse, out level) || !(level >= 1 && level <= 10))
    {
        Console.WriteLine("Not a valid number, try again.");
        Console.Write("Level (1-10): ");
        parse = Console.ReadLine();
    }
    IPlayer player1 = new Player(name, surname, level);

    // insert player 2
    Console.WriteLine();
    Console.WriteLine("\tPlayer2");
    Console.Write("Name: ");
    name = Console.ReadLine();
    Console.Write("SurName: ");
    surname = Console.ReadLine();
    Console.Write("Level (1-10): ");
    parse = Console.ReadLine();
    while (!Int32.TryParse(parse, out level) || !(level >= 1 && level <= 10))
    {
        Console.WriteLine("Not a valid number, try again.");
        Console.Write("Level (1-10): ");
        parse = Console.ReadLine();
    }
    IPlayer player2 = new Player(name, surname, level);

    while (samePlayer)
    {
        samePlayer = false;

        Console.WriteLine();
        Console.WriteLine("\t\tPlay Game");
        Console.WriteLine();
        Console.WriteLine($"Player1: {player1.Name} {player1.Surname} \tPlayer2: {player2.Name} {player2.Surname}");

        // set simulation game
        IGame game = new Game(player1, player2);
        //Thread.Sleep(new Random().Next(2000, 10000));

        // play game
        while (game.PlayGame(out result))
        {
            Console.WriteLine(result);
            //Thread.Sleep(new Random().Next(2000, 10000));
        }
        Console.WriteLine();
        Console.WriteLine(result);

        // restart or play another game
        Console.WriteLine();
        Console.WriteLine("Play Again? (y/n)");
        if (!Console.ReadLine().Equals("y")) Environment.Exit(0);
        Console.WriteLine();
        Console.WriteLine("Same Player? (y/n)");
        if (Console.ReadLine().Equals("y")) samePlayer = true;
    }

}

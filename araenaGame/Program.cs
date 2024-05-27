using System;
using System.Threading.Tasks;
using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleArenaGame
{
    class Program
    {
        static void ConsoleNotification(GameEngine.NotificationArgs args)
        {
            Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.");
            Console.WriteLine($"Attacker: {args.Attacker}");
            Console.WriteLine($"Defender: {args.Defender}");
        }

        static Hero SelectHero()
        {
            Console.WriteLine("Select a Hero:");
            Console.WriteLine("1. Knight");
            Console.WriteLine("2. Assassin");
            Console.WriteLine("3. Mage");
            Console.WriteLine("4. Tank");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    return new Knight("Knight", 10, 20, new Sword("Sword"));
                case 2:
                    return new Assassin("Assassin", 10, 5, new Dagger("Dagger"));
                case 3:
                    return new Mage("Mage", 5, 15, new Staff("Staff"));
                case 4:
                    return new Tank("Tank", 20, 10, new Shield("Shield"));
                default:
                    Console.WriteLine("Invalid choice, defaulting to Knight.");
                    return new Knight("Knight", 10, 20, new Sword("Sword"));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Arena Game!");

            Console.WriteLine("Player 1:");
            Hero heroA = SelectHero();

            Console.WriteLine("Player 2:");
            Hero heroB = SelectHero();

            GameEngine gameEngine = new GameEngine()
            {
                HeroA = heroA,
                HeroB = heroB,
                NotificationsCallBack = ConsoleNotification
            };

            gameEngine.Fight();

            Console.WriteLine();
            Console.WriteLine($"And the winner is {gameEngine.Winner}");
        }
    }
}
using System;

namespace Monster_Card_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            User Pole = new User();
            Pole.UserName = "Patrick";
            Pole.UserPassword = "12345";
            Pole.UserCoins = 100;

            Console.WriteLine(Pole.UserName);
            Console.WriteLine(Pole.UserPassword);
            Console.WriteLine(Pole.UserCoins);

            NormalGoblin A = new NormalGoblin();

        }
    }
}


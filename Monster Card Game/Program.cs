
using System;
using System.Collections.Generic;

namespace Monster_Card_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            User Pole = new User();
            User Enemy = new User();

            Pole.UserName = "Patrick";
            Pole.UserPassword = "12345";
            Pole.BuyPack();
            Enemy.BuyPack();
            Battle Battle = new Battle();

            Battle.StartBattle(Pole, Enemy);
            //Pole.CreateBattledeck();
            //Enemy.CreateBattledeck();

            //Console.WriteLine(Pole.CardCollection[0].CardName);


        }
    }
}


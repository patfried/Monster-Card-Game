
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
            Battle Battle = new Battle();

            Pole.UserName = "patrick";
            Pole.UserPassword = "12345";
            Pole.InsertUserintoDB();
            Pole.UserCoins = 200;
            Pole.UpdateUser();
            //Pole.DeleteUser();
            //Pole.BuyPack();
            //Enemy.BuyPack();


            //Battle.StartBattle(Pole, Enemy);
            //Pole.CreateBattledeck();
            //Enemy.CreateBattledeck();

            //Console.WriteLine(Pole.CardCollection[0].CardName);


        }
    }
}


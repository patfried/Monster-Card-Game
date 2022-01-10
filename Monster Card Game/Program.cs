
using System;
using System.Collections.Generic;

namespace Monster_Card_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            User Pole = new User("Patrick","12345");
            //User Enemy = new User("Kevin","Klauber");
            Battle Battle = new Battle();
            Database db = new Database();

            Pole.CreateStackFromDB();
            Pole.printstack();

            //Pole.BuyPacks();
            //Pole.InsertStackIntoDB();
            //Enemy.BuyPacks();
            //Enemy.InsertStackIntoDB();
            //Pole.UserCoins = 200;
            //Pole.UpdateUser();
            //Pole.DeleteUser();

            db.Connection.Close();


            //Battle.StartBattle(Pole, Enemy);
            //Pole.CreateBattledeck();
            //Enemy.CreateBattledeck();

            //Console.WriteLine(Pole.CardCollection[0].CardName);


        }
    }
}


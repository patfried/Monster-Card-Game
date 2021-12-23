﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    public abstract class AbstractCard : ICard
    {

        public string CardName { get; set; }
        public  int CardDamage { get; set; }
        public enum Element
        {
            NORMAL, FIRE, WATER
        }
        public Element CardElement { get; set; }
        public string CardType { get; set; }
        ICard.Element ICard.CardElement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } // TODO herausfinden warum!!!

        public void Created()
        {
            Console.WriteLine($"{CardName} was created sucsessfully!");
        }
    }
}
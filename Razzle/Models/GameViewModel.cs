using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Razzle.Models
{
    public class GameViewModel
    {
        public string PlayerOne { get; set; }
        public string PlayerTwo { get; set; }
        public string[] GameBoard { get; set; }

        public GameViewModel(string playerone, string playertwo)
        {
            PlayerOne = playerone;
            PlayerTwo = playertwo;
            GameBoard = new string[16];
            for (var i = 0; i < AllDice.Count(); i++)
            {
                int rand = new Random().Next(0,5);
                string randletter = AllDice[i][rand];
                GameBoard[i] = randletter;
            
            }
            GameBoard = Shuffle(GameBoard);

        }


        //DICE
        private static string[] die_one = { "A", "A", "C", "I", "O", "T" };
        private static string[] die_two = { "A", "B", "I", "L", "T", "Y"};
        private static string[] die_three = { "A", "B", "J", "M", "O", "Qu"};
        private static string[] die_four = { "A", "C", "D", "E", "M", "P"};
        private static string[] die_five = { "A", "C", "E", "L", "R", "S"};
        private static string[] die_six = { "A", "D", "E", "N", "V", "Z"};
        private static string[] die_seven = { "A", "H", "M", "O", "R", "S"};
        private static string[] die_eight = { "B", "I", "F", "O", "R", "X"};
        private static string[] die_nine = { "D", "E", "N", "O", "S", "W"};
        private static string[] die_ten = { "D", "K", "N", "O", "T", "U"};
        private static string[] die_eleven = { "E", "E", "F", "H", "I", "Y"};
        private static string[] die_twelve = { "E", "G", "K", "L", "U", "Y"};
        private static string[] die_thirteen = { "E", "G", "I", "N", "T", "V"};
        private static string[] die_fourteen = { "E", "H", "I", "N", "P", "S"};
        private static string[] die_fifteen = { "E", "L", "P", "S", "T", "U"};
        private static string[] die_sixteen = { "G", "I", "L", "R", "U", "W"};

        //ALL DICE
        private string[][] AllDice = {die_one,die_two,die_three,die_four,
            die_five,die_six,die_seven,die_eight,die_nine,die_ten,die_eleven,
            die_twelve,die_thirteen,die_fourteen,die_fifteen,die_sixteen};

        //Fisher Yates Shuffle Copied From DotNetPearls
        static Random _random = new Random();

        private string[] Shuffle(string[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                // NextDouble returns a random number between 0 and 1.
                // ... It is equivalent to Math.random() in Java.
                int r = i + (int)(_random.NextDouble() * (n - i));
                string t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
            return array;
        }



    }
}
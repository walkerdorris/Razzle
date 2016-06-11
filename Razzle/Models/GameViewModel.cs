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
            GameBoard = new string[16] { "a","b","c","d",
                "a", "b", "c", "d","a","b","c","d","a","b","c","d" };

        }


        //DICE
        private string[] die_one = { "A", "A", "C", "I", "O", "T" };
        private string[] die_two = { "A", "B", "I", "L", "T", "Y"};
        private string[] die_three = { "A", "B", "J", "M", "O", "Qu"};
        private string[] die_four = { "A", "C", "D", "E", "M", "P"};
        private string[] die_five = { "A", "C", "E", "L", "R", "S"};
        private string[] die_six = { "A", "D", "E", "N", "V", "Z"};
        private string[] die_seven = { "A", "H", "M", "O", "R", "S"};
        private string[] die_eight = { "B", "I", "F", "O", "R", "X"};
        private string[] die_nine = { "D", "E", "N", "O", "S", "W"};
        private string[] die_ten = { "D", "K", "N", "O", "T", "U"};
        private string[] die_eleven = { "E", "E", "F", "H", "I", "Y"};
        private string[] die_twelve = { "E", "G", "K", "L", "U", "Y"};
        private string[] die_thirteen = { "E", "G", "I", "N", "T", "V"};
        private string[] die_fourteen = { "E", "H", "I", "N", "P", "S"};
        private string[] die_fifteen = { "E", "L", "P", "S", "T", "U"};
        private string[] die_sixteen = { "G", "I", "L", "R", "U", "W"};


    }
}
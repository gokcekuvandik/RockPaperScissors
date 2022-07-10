using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.UI.Model
{
    public class Enums
    {
        public enum Hand
        {
            Rock,
            Paper,
            Scissors
        }

        public enum GameResult
        {
            Win,
            Lose,
            Tie
        }
    }
}

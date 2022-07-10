using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.UI.Model
{
    public class Game : BaseModel
    {
        private int turn;
        public int Turn { get => turn; set { turn = value; OnPropertyChanged(); } }

        private Player playerA;
        public Player PlayerA { get => playerA; set { playerA = value; OnPropertyChanged(); } }

        private Player playerB;
        public Player PlayerB { get => playerB; set { playerB = value; OnPropertyChanged(); } }

        public Game(int _turn, Player _playerA, Player _playerB)
        {
            Turn = _turn;
            PlayerA = _playerA;
            PlayerB = _playerB;
        }
    }
}

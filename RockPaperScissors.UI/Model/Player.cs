using RockPaperScissors.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RockPaperScissors.UI.Model.Enums;

namespace RockPaperScissors.UI.Model
{
    public class Player : BaseModel
    {
        public Player(Hand _hand)
        {
            Hand = _hand;
        }

        private Hand hand;
        public Hand Hand { get => hand; set { hand = value; SetImage(hand); OnPropertyChanged(); } }

        private Bitmap image;
        public Bitmap Image { get => image; set { image = value; OnPropertyChanged(); } }

        private GameResult result;
        public GameResult Result { get => result; set { result = value; OnPropertyChanged(); } }

        private void SetImage(Hand hand)
        {
            switch (hand)
            {
                case Hand.Rock:
                    Image = Resources.rock;
                    break;
                case Hand.Paper:
                    Image = Resources.paper;
                    break;
                case Hand.Scissors:
                    Image = Resources.scissors;
                    break;
                default:
                    break;
            }
        }
    }
}

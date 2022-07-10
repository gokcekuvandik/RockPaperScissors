using RockPaperScissors.UI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static RockPaperScissors.UI.Model.Enums;

namespace RockPaperScissors.UI.ViewModel
{
    public class MainWindowVM : BaseModel
    {
        #region Constructor
        public MainWindowVM()
        {
            InitializeLookup();

            StartGameSession(100);
        }
        #endregion


        #region Properties
        private Dictionary<Hand, Hand> Lookup { get; set; }

        private Player playerA;
        public Player PlayerA { get => playerA; set { playerA = value; OnPropertyChanged(); } }

        private Player playerB;
        public Player PlayerB { get => playerB; set { playerB = value; OnPropertyChanged(); } }

        private ObservableCollection<Game> summary = new ObservableCollection<Game>();

        public ObservableCollection<Game> Summary { get => summary; set { summary = value; OnPropertyChanged(); } }

        private int round;
        public int Round { get => round; set { round = value; OnPropertyChanged(); } }
        #endregion



        #region Methods
        private void InitializeLookup()
        {
            Lookup = new Dictionary<Hand, Hand>()
            {
                { Hand.Paper, Hand.Rock},
                { Hand.Rock, Hand.Scissors},
                { Hand.Scissors, Hand.Paper}
            };
        }

        private async void StartGameSession(int sessionCount)
        {
            for (int i = 1; i <= sessionCount; i++)
            {
                Round = i;
                PlayerA = new Player(Hand.Rock);

                var move = new Random().Next(Lookup.Count);
                PlayerB = new Player((Hand)move);

                await SetWinner(PlayerA, PlayerB);

                await Task.Delay(500);

                await Clean(i, PlayerA, PlayerB);

                await Task.Delay(500);

                Summary.Add(new Game(i, PlayerA, PlayerB));
            }
        }

        private async Task Clean(int i, Player playerA, Player playerB)
        {
            PlayerA.Image = PlayerB.Image = null;
        }

        private async Task SetWinner(Player playerA, Player playerB)
        {
            if (playerA.Hand == playerB.Hand)
                PlayerA.Result = PlayerB.Result = GameResult.Tie;
            else
            {
                Hand res;
                Lookup.TryGetValue(playerB.Hand, out res);

                if (res == playerA.Hand)
                {
                    PlayerA.Result = GameResult.Lose;
                    PlayerB.Result = GameResult.Win;
                }
                else
                {
                    PlayerA.Result = GameResult.Win;
                    PlayerB.Result = GameResult.Lose;
                }
            }

        }
        #endregion
    }
}

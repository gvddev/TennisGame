using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TennisGame;

namespace TennisGame.Model
{
    internal class Game : IGame
    {
        private IPlayer _player1;
        private IPlayer _player2;
        private int _point;

        public Game(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
            _player1.Score = _player2.Score = TennisScore.Love;
            _point = 1;
        }

        public bool PlayGame(out string result)
        {
            // assign point, return if it not assigned
            if(AssignPoint())
            {
                // check status game, return true if game continue else false if game end
                if (!CheckGameScore())
                {
                    // end game
                    result = _player1.Score > _player2.Score ?
                        $"#{_point}\t\tPlayer {_player1.Name} {_player1.Surname} wins" :
                        $"#{_point}\t\tPlayer {_player2.Name} {_player2.Surname} wins";
                    return false;
                }
                
                // score game
                result = $"#{_point}\t\t{_player1.Score.ToString()} - {_player2.Score.ToString()}";
                _point++;
                return true;
            }

            // playing point
            result = $"#{_point}\t\tplaying . . .";
            return true;
        }

        private bool AssignPoint()
        {
            // set force and gap between forceP1 and forceP2
            double forceP1 = Forces(_player1);
            double forceP2 = Forces(_player2);
            double misForce = forceP1 - forceP2;
            // assign point player1, if advantage player2 return deuce
            if (misForce > 0.5)
            {
                _player1.Score++;
                return true;
            }
            // assign point player2, if advantage player1 return deuce
            if (misForce < -0.5)
            {
                _player2.Score++;
                return true;
            }
            return false;
        }

        private bool CheckGameScore()
        {
            // set misscore
            int misScore = Math.Abs(_player1.Score - _player2.Score);

            // check deuce
            if (_player1.Score == _player2.Score && _player1.Score >= TennisScore.Forty)
            {
                _player1.Score = _player2.Score = TennisScore.Deuce;
                return true;
            }

            // check win
            if ((_player1.Score > TennisScore.Forty || _player2.Score > TennisScore.Forty) && misScore > 1)
            {
                return false;
            }

            // anyother score
            return true;
        }

        private double Forces(IPlayer player)
        {
            int goodLuck = new Random().Next(1, 10);
            int status = new Random().Next(1, 10);
            // base on status
            int focus = new Random().Next(status, 10);
            // base on fitness
            int power = new Random().Next(player.Fitness, 10);
            int overall = player.Level + player.Fitness + status + focus + goodLuck + power;
            return overall / 6;
        }
    }
}

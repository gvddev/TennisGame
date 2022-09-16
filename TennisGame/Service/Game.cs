using System;
using System.Collections.Generic;
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
            double forceP1 = Forces(_player1);
            double forceP2 = Forces(_player2);
            double misForce = forceP1 - forceP2;
            if (misForce >= -0.5 && misForce <= 0.5)
            {
                result = $"#{_point}\t\tplaying . . .";
                return true;
            };

            assignPoint(forceP1, forceP2, misForce);

            int misScore = _player1.Score - _player2.Score;
            if (_player1.Score == TennisScore.Forty && _player2.Score == TennisScore.Forty)
            {
                _player1.Score++;
                _player2.Score++;
                result = $"#{_point}\t\t{_player1.Score.ToString()} - {_player2.Score.ToString()}";
                _point++;
                return true;
            }
            if (_player1.Score > TennisScore.Forty || _player2.Score > TennisScore.Forty)
            {
                if (misScore > 1)
                {
                    result = $"#{_point}\t\tPlayer {_player1.Name} {_player1.Surname} wins";
                    return false;
                }
                if (misScore < -1)
                {
                    result = $"#{_point}\t\tPlayer {_player2.Name} {_player2.Surname} wins";
                    return false;
                }
            }
            result = $"#{_point}\t\t{_player1.Score.ToString()} - {_player2.Score.ToString()}";
            _point++;
            return true;
        }

        private void assignPoint(double force1, double force2, double misforce)
        {
            if (misforce > 0 && force1 <= 9 || misforce < 0 && force2 > 9)
            {
                if (_player2.Score == TennisScore.Advantage)
                    _player2.Score--;
                else
                    _player1.Score++;
            }
            if (misforce < 0 && force2 <= 9 || misforce > 0 && force1 > 9)
            {

                if (_player1.Score == TennisScore.Advantage)
                    _player1.Score--;
                else
                    _player2.Score++;
            }
        }

        private double Forces(IPlayer player)
        {
            int goodLuck = new Random().Next(1, 10);
            int power = new Random().Next(1, 10);
            int overall = player.Level + player.Status + goodLuck + power;
            return overall / 4;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    /// <summary>
    ///     Tennis Player
    /// </summary>
    internal class Player : IPlayer
    {
        private string _name;
        private string _surname;
        private int _level;
        private int _status;
        private TennisScore _score;

        public Player(string name, string surname, int level)
        {
            Name = name;
            Surname = surname;
            Level = level;
            Status = new Random().Next(1, 10);
            Score = TennisScore.Love;
        }

        public string Name { get => _name; internal set => _name = value; }
        public string Surname { get => _surname; internal set => _surname = value; }
        public int Level { get => _level; internal set => _level = value;}
        public int Status { get => _status; internal set => _status = value; }
        public TennisScore Score { get => _score; set => _score = value; }
    }
}

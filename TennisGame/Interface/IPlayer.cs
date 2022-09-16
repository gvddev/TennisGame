using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    /// <summary>
    ///     Interface Tennis Player
    /// </summary>
    internal interface IPlayer
    {
        public string Name { get; }
        public string Surname { get; }
        public int Level { get; }
        public int Status { get; }
        public TennisScore Score { get; set; }
    }
}

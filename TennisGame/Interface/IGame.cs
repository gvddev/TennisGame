using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    /// <summary>
    ///     Interface Tennis Game
    /// </summary>
    internal interface IGame
    {
        /// <summary>
        ///     Play Tennis Game Simulator: 
        ///     random point assignment based on 6 player characteristics
        ///     'level' input user, 'fitness' indipendent random, 'goodluck' ind. random, 'status' ind. random,
        ///     'focus' random base on 'status', 'power' random base on 'fitness'
        /// </summary>
        /// <returns>Status Game: playing if true; end play if false</returns>
        bool PlayGame(out string result);
    }
}

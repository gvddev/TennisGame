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
        ///     Play Tennis Game
        /// </summary>
        /// <returns>Status Game: true or false</returns>
        bool PlayGame(out string result);
    }
}

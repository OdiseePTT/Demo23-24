using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public enum GameState
    {
        LetterIsPresent,
        LetterIsNotPresent,
        LetterAlreadyGuessed,
        GameWon,
        GameLost
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanGame
    {
        private string _pickedWord;
        private HashSet<char> _guessedCharacters = new HashSet<char>();
        private IWordRepository _wordRepository;

        public HangmanGame(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
            ResetGame();
        }

        public string WordToGuess { 
            get {
                char[] chars = _pickedWord.Select(c => _guessedCharacters.Contains(c) ? c : '_').ToArray();
                return new string(chars) ;
            }
        }

        public int Lives { get; private set; } = 10;

        public GameState GuessLetter(char c)
        {
            if (!_guessedCharacters.Add(c))
            {
                return GameState.LetterAlreadyGuessed;
            }

            if (_pickedWord.Contains(c))
            {
              /*  if(_guessedCharacters.Count == _pickedWord.Distinct().Count())
                {
                    return GameState.GameWon;
                } */   

                if(_pickedWord == WordToGuess)
                {
                    return GameState.GameWon;
                }

                return GameState.LetterIsPresent;
            }

            Lives--;

            if (Lives <= 0)
            {
                return GameState.GameLost;
            }

            return GameState.LetterIsNotPresent;
        }

        public void ResetGame()
        {
            Lives = 10;
            _guessedCharacters.Clear();
            _pickedWord = _wordRepository.GetRandomWord();
        }
    }
}

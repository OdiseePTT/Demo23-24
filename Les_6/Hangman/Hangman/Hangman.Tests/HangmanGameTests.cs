using System;

namespace Hangman.Tests
{

    // V  Er wordt voor de speler een random woord gekozen
    // V  De speler ziet dit woord doormiddel van liggende streepjes(elk streepje is 1 letter)
    //  De gebruiker kan letters raden
    //  V    Wanneer een letter reeds geraden is krijgt de gebruiker hier een melding van.
    //  V    Wanneer een letter nog niet geraden is en in het woord voorkomt, wordt deze letter in het woord vervangen door de effectieve letter.
    //  V    Wanneer een letter nog niet geraden is en niet in het woord voorkomt, verliest de gebruiker een leven.
    //  V De speler is gewonnen wanneer alle letters geraden zijn.
    //  V De speler is verloren wanneer alle levens op zijn.
    //  V Het spel kan opnieuw gereset worden met een nieuw woord.

    public class HangmanGameTests
    {

        [Fact]
        public void Ctor_WithWordsRepo_CallsGetRandomWord()
        {
            // Arrange
            IWordRepository repo = Substitute.For<IWordRepository>(); 

            // Act
            HangmanGame sut = new HangmanGame(repo);

            // Assert 
            repo.Received(1).GetRandomWord();
        }

        [Fact]
        public void WordToGuess_RandomWordApple_Returns5underscores()
        {
            // Arrange
            IWordRepository wordRepository = Substitute.For<IWordRepository>();
            wordRepository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(wordRepository);

            // Act
            string result = sut.WordToGuess;

            // Assert
            result.Should().Be("_____");
        }

        [Theory]
        [InlineData("pear", "____")]
        [InlineData("banana", "______")]
        [InlineData("mandarijn", "_________")]
        public void WordToGuess_WithWord_ReturnsExpectedNumberOfUnderscores(string word, string expecedResult) {

            // Arrange
            IWordRepository wordRepository = Substitute.For<IWordRepository>();
            wordRepository.GetRandomWord().Returns(word);
            HangmanGame sut = new HangmanGame(wordRepository);

            // Act
            string actualResult = sut.WordToGuess;

            // Assert
            actualResult.Should().Be(expecedResult);
        }

        [Fact]
        public void GuessLetter_LetterInWordAndNotGuessedBefore_ReturnsLetterIsPresent()
        {

            // Arrange
            IWordRepository repository = Substitute.For<IWordRepository>();
            repository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(repository);

            // Act
            GameState result = sut.GuessLetter('a');

            // Assert
            result.Should().Be(GameState.LetterIsPresent);
        }

        [Fact]
        public void GuessLetter_LetterNotInWordAndNotGuessedBefore_ReturnsLetterIsNotPresent()
        {
            // Arrange
            IWordRepository repository = Substitute.For<IWordRepository>();
            repository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(repository);

            // Act
            GameState result = sut.GuessLetter('b');

            // Assert
            result.Should().Be(GameState.LetterIsNotPresent);
        }

        [Fact]
        public void Lives_OnStart_AreEqualTo10()
        {

            // Arrange
            IWordRepository repository = Substitute.For<IWordRepository>();
            HangmanGame sut = new HangmanGame(repository);

            // Act
            int lives = sut.Lives;

            // Assert
            lives.Should().Be(10);
        }

        [Fact]
        public void Lives_After1WrongQuess_AreEqualTo9()
        {
            // Arrange
            IWordRepository repository = Substitute.For<IWordRepository>();
            repository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(repository);
            sut.GuessLetter('b');

            // Act
            int lives = sut.Lives;

            // Assert
            lives.Should().Be(9);
        }

        [Fact]
        public void Lives_After5WrongQuess_AreEqualTo5()
        {
            // Arrange
            IWordRepository repository = Substitute.For<IWordRepository>();
            repository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(repository);
            sut.GuessLetter('b');
            sut.GuessLetter('c');
            sut.GuessLetter('d');
            sut.GuessLetter('f');
            sut.GuessLetter('g');

            // Act
            int lives = sut.Lives;

            // Assert
            lives.Should().Be(5);
        }

        [Fact]
        public void Lives_AfterCorrectGuess_DoesntChange()
        {
            // Arrange
            IWordRepository repository = Substitute.For<IWordRepository>();
            repository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(repository);
            sut.GuessLetter('a');

            // Act
            int lives = sut.Lives;

            // Assert
            lives.Should().Be(10);
        }

        [Fact]
        public void GuessLetter_WithLetterAlreadyGuessed_ReturnsLetterAlreadyGuessed()
        {
            // Arrange
            IWordRepository repository = Substitute.For<IWordRepository>();
            repository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(repository);
            sut.GuessLetter('a');

            // Act
            GameState result = sut.GuessLetter('a');

            // Arrange
            result.Should().Be(GameState.LetterAlreadyGuessed);
        }


        [Fact]
        public void Lives_AfterGuessWithAlreadyPickedChar_DoesntChange()
        {
            // Arrange
            IWordRepository repository = Substitute.For<IWordRepository>();
            repository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(repository);
            sut.GuessLetter('b');
            sut.GuessLetter('b');

            // Act
            int lives = sut.Lives;

            // Assert
            lives.Should().Be(9);
        }

        [Fact]
        public void WordToGuess_AfterCorrectGuess_CorrectLettersAreVisible()
        {

            // Arrange
            IWordRepository wordRepository = Substitute.For<IWordRepository>();
            wordRepository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(wordRepository);
            sut.GuessLetter('a');

            // Act
            string result = sut.WordToGuess;

            // Assert
            result.Should().Be("a____");

        }

        [Fact]
        public void WordToGuess_LastCorrectLetterIsGuessed_ReturnsGameWon()
        {
            // Arrange
            IWordRepository wordRepository = Substitute.For<IWordRepository>();
            wordRepository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(wordRepository);
            sut.GuessLetter('a');
            sut.GuessLetter('p');
            sut.GuessLetter('l');

            // Act
            GameState result = sut.GuessLetter('e');

            // Assert
            result.Should().Be(GameState.GameWon);
        }

        [Fact]
        public void WordToGuess_With10WrongGuesses_ReturnsGameLost()
        {
            // Arrange
            IWordRepository wordRepository = Substitute.For<IWordRepository>();
            wordRepository.GetRandomWord().Returns("apple");
            HangmanGame sut = new HangmanGame(wordRepository);
            sut.GuessLetter('b');
            sut.GuessLetter('c');
            sut.GuessLetter('d');
            sut.GuessLetter('f');
            sut.GuessLetter('i');
            sut.GuessLetter('j');
            sut.GuessLetter('k');
            sut.GuessLetter('m');
            sut.GuessLetter('n');

            // Act
            GameState result = sut.GuessLetter('o');

            // Assert
            result.Should().Be(GameState.GameLost);
        }

        [Fact]
        public void ResetGame_WithGamePlayed_ResetLivesAndWordToGuessIsBlankAndPicksNewWord()
        {
            // Arrange
            IWordRepository wordRepository = Substitute.For<IWordRepository>();
            wordRepository.GetRandomWord().Returns("apple", "pear");
            HangmanGame sut = new HangmanGame(wordRepository);
            sut.GuessLetter('a');
            sut.GuessLetter('b');
            sut.GuessLetter('c');
            sut.GuessLetter('d');
            sut.GuessLetter('e');
            sut.GuessLetter('p');
            sut.GuessLetter('g');
            sut.GuessLetter('h');
            sut.GuessLetter('l');
            wordRepository.ClearReceivedCalls();

            // Act
            sut.ResetGame();

            // Assert
            sut.Lives.Should().Be(10);
            sut.WordToGuess.Should().Be("____");
            wordRepository.Received(1).GetRandomWord();
        }
    }
}

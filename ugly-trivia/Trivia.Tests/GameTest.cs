using Newtonsoft.Json;
using NUnit.Framework;
namespace Trivia.Tests;
public class GameTest
{
    [Test]
    public void Recolect()
    {
        var aGame = new PrinterGameForTesting();

        aGame.Add("Kilian");
        aGame.Add("Antonio");
        aGame.Add("Rafa");
        aGame.Add("Fran");
        aGame.Add("Raul");
        aGame.Run();
        ToFile(string.Join(",", aGame._diceNumbers), "diceNumbers.txt");
        ToFile(string.Join(",", aGame._wrongAnwers.Select(x => x.ToString().ToLower())), "wrongAnwers.txt");
        ToFile(string.Join(",", aGame._displayMessages.Select(m => $"\"{m}\"")), "expectedDisplays.txt");
    }
    private void ToFile(string text, string filename)
    {
        File.WriteAllText(@"C:\Codesai\forks practicas deliveradas\changing-legacy-training-csharp\ugly-trivia\Trivia.Tests\" + filename, text);
    }
    public class PrinterGameForTesting : Game
    {
        public List<int> _diceNumbers;
        public List<string> _displayMessages;
        public List<bool> _wrongAnwers;
        public PrinterGameForTesting()
        {
            _wrongAnwers = new List<bool>();
            _diceNumbers = new List<int>();
            _displayMessages = new List<string>();
        }
        protected override void Display(string message)
        {
            _displayMessages.Add(message);
        }
        protected override int GetDiceNumber()
        {
            var diceNumber = base.GetDiceNumber();
            _diceNumbers.Add(diceNumber);
            return diceNumber;
        }
        protected override bool IsWrongAnswer()
        {
            var isWrongAnswer = base.IsWrongAnswer();
            _wrongAnwers.Add(isWrongAnswer);
            return isWrongAnswer;
        }
    }
    [Test]
    public void Run()
    {
        var aGame = new GameForTesting();
        aGame._diceNumbers = File2List("diceNumbers.txt");
        aGame._wrongAnwers = File2List("wrongAnwers.txt");
        aGame.Add("Kilian");
        aGame.Add("Antonio");
        aGame.Add("Rafa");
        aGame.Add("Fran");
        aGame.Add("Raul");
        var expected = File2String("expectedDisplays.txt");

        aGame.Run();
        ToFile(string.Join(",", aGame._displayMessages.Select(m => $"\"{m}\"")), "displays.txt");
        var result = File2String("displays.txt");

        Assert.That(result, Is.EqualTo(expected));
    }

    private string File2String(string filename)
    {
        return File.ReadAllText(
            @"C:\Codesai\forks practicas deliveradas\changing-legacy-training-csharp\ugly-trivia\Trivia.Tests\" +
            filename);
    }

    private List<string> File2List(string filename)
    {
        var stringFile = File.ReadAllText(
            @"C:\Codesai\forks practicas deliveradas\changing-legacy-training-csharp\ugly-trivia\Trivia.Tests\" +
            filename);
        return stringFile.Split(',').ToList();
    }

    public class GameForTesting : Game
    {
        public List<string> _diceNumbers;
        public List<string> _displayMessages;
        public List<string> _wrongAnwers;
        private int _diceNumbersCount;
        private int _wrongAnswerCount;
        public GameForTesting()
        {
            _wrongAnwers = new List<string>();
            _diceNumbers = new List<string>();
            _displayMessages = new List<string>();
        }
        protected override void Display(string message)
        {
            _displayMessages.Add(message);
        }
        protected override int GetDiceNumber()
        {
            var diceNumber = Convert.ToInt32(_diceNumbers[_diceNumbersCount]);
            _diceNumbersCount++;
            return diceNumber;
        }
        protected override bool IsWrongAnswer()
        {
            var isWrongAnswer = Convert.ToBoolean(_wrongAnwers[_wrongAnswerCount]);
            _wrongAnswerCount++;
            return isWrongAnswer;
        }
    }
}
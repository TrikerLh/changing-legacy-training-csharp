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
        ToFile(string.Join(",", aGame._displayMessages.Select(m => $"\"{m}\"")), "displays.txt");
    }
    private void ToFile(string text, string filename)
    {
        File.WriteAllText(@"C:\Users\rgayoso\Documents\Git\CodeSai-My-Repos\changing-legacy-training-csharp\ugly-trivia\Trivia.Tests" + filename, text);
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
        aGame._diceNumbers = new List<int>
        {
            2,5,2,2,4,5,3,1,5,4,3,5,3,5,1,1,1,1,2,3,4,5,2,4,1,3
        };
        aGame._wrongAnwers = new List<bool>
        {
            false,false,false,false,false,false,false,false,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false

        };
        var _expectedDisplayMessages = new List<string>
        {
            "Kilian was added","They are player number 1","Antonio was added",
            "They are player number 2",
            "Rafa was added",
            "They are player number 3",
            "Fran was added","They are player number 4","Raul was added","They are player number 5","Kilian is the current player","They have rolled a 2","Kilian's new location is 2","The category is Sports","Sports Question 0","Answer was corrent!!!!","Kilian now has 1 Gold Coins.","Antonio is the current player","They have rolled a 5","Antonio's new location is 5","The category is Science","Science Question 0","Answer was corrent!!!!","Antonio now has 1 Gold Coins.","Rafa is the current player","They have rolled a 2","Rafa's new location is 2","The category is Sports","Sports Question 1","Answer was corrent!!!!","Rafa now has 1 Gold Coins.","Fran is the current player","They have rolled a 2","Fran's new location is 2","The category is Sports","Sports Question 2","Answer was corrent!!!!","Fran now has 1 Gold Coins.","Raul is the current player","They have rolled a 4","Raul's new location is 4","The category is Pop","Pop Question 0","Answer was corrent!!!!","Raul now has 1 Gold Coins.","Kilian is the current player","They have rolled a 5","Kilian's new location is 7","The category is Rock","Rock Question 0","Answer was corrent!!!!","Kilian now has 2 Gold Coins.","Antonio is the current player","They have rolled a 3","Antonio's new location is 8","The category is Pop","Pop Question 1","Answer was corrent!!!!","Antonio now has 2 Gold Coins.","Rafa is the current player","They have rolled a 1","Rafa's new location is 3","The category is Rock","Rock Question 1","Answer was corrent!!!!","Rafa now has 2 Gold Coins.","Fran is the current player","They have rolled a 5","Fran's new location is 7","The category is Rock","Rock Question 2","Question was incorrectly answered","Fran was sent to the penalty box","Raul is the current player","They have rolled a 4","Raul's new location is 8","The category is Pop","Pop Question 2","Answer was corrent!!!!","Raul now has 2 Gold Coins.","Kilian is the current player","They have rolled a 3","Kilian's new location is 10","The category is Sports","Sports Question 3","Answer was corrent!!!!","Kilian now has 3 Gold Coins.","Antonio is the current player","They have rolled a 5","Antonio's new location is 1","The category is Science","Science Question 1","Answer was corrent!!!!","Antonio now has 3 Gold Coins.","Rafa is the current player","They have rolled a 3","Rafa's new location is 6","The category is Sports","Sports Question 4","Answer was corrent!!!!","Rafa now has 3 Gold Coins.","Fran is the current player","They have rolled a 5","Fran is getting out of the penalty box","Fran's new location is 0","The category is Pop","Pop Question 3","Answer was correct!!!!","Fran now has 2 Gold Coins.","Raul is the current player","They have rolled a 1","Raul's new location is 9","The category is Science","Science Question 2","Answer was corrent!!!!","Raul now has 3 Gold Coins.","Kilian is the current player","They have rolled a 1","Kilian's new location is 11","The category is Rock","Rock Question 3","Answer was corrent!!!!","Kilian now has 4 Gold Coins.","Antonio is the current player","They have rolled a 1","Antonio's new location is 2","The category is Sports","Sports Question 5","Answer was corrent!!!!","Antonio now has 4 Gold Coins.","Rafa is the current player","They have rolled a 1","Rafa's new location is 7","The category is Rock","Rock Question 4","Answer was corrent!!!!","Rafa now has 4 Gold Coins.","Fran is the current player","They have rolled a 2","Fran is not getting out of the penalty box","Raul is the current player","They have rolled a 3","Raul's new location is 0","The category is Pop","Pop Question 4","Answer was corrent!!!!","Raul now has 4 Gold Coins.","Kilian is the current player","They have rolled a 4","Kilian's new location is 3","The category is Rock","Rock Question 5","Answer was corrent!!!!","Kilian now has 5 Gold Coins.","Antonio is the current player","They have rolled a 5","Antonio's new location is 7","The category is Rock","Rock Question 6","Answer was corrent!!!!","Antonio now has 5 Gold Coins.","Rafa is the current player","They have rolled a 2","Rafa's new location is 9","The category is Science","Science Question 3","Answer was corrent!!!!","Rafa now has 5 Gold Coins.","Fran is the current player","They have rolled a 4","Fran is not getting out of the penalty box","Raul is the current player","They have rolled a 1","Raul's new location is 1","The category is Science","Science Question 4","Answer was corrent!!!!","Raul now has 5 Gold Coins.","Kilian is the current player","They have rolled a 3","Kilian's new location is 6","The category is Sports","Sports Question 6","Answer was corrent!!!!","Kilian now has 6 Gold Coins."
        };
        aGame.Add("Kilian");
        aGame.Add("Antonio");
        aGame.Add("Rafa");
        aGame.Add("Fran");
        aGame.Add("Raul");
        aGame.Run();
        Assert.That(aGame._displayMessages, Is.EquivalentTo(_expectedDisplayMessages));
    }
    public class GameForTesting : Game
    {
        public List<int> _diceNumbers;
        public List<string> _displayMessages;
        public List<bool> _wrongAnwers;
        private int _diceNumbersCount;
        private int _wrongAnswerCount;
        public GameForTesting()
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
            var diceNumber = _diceNumbers[_diceNumbersCount];
            _diceNumbersCount++;
            return diceNumber;
        }
        protected override bool IsWrongAnswer()
        {
            var isWrongAnswer = _wrongAnwers[_wrongAnswerCount];
            _wrongAnswerCount++;
            return isWrongAnswer;
        }
    }
}
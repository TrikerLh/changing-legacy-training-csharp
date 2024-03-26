namespace Trivia
{
    public class GameRunner
    {

        public static void Main(string[] args)
        {
            var aGame = new Game();

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            aGame.Run();
        }
    }
}
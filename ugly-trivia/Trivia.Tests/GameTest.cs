
using NUnit.Framework;

namespace Trivia.Tests;

public class GameTest
{
    [Test]
    public void fix_me()
    {
        var game = new Game();

        game.Add("Chet");
        game.Roll(323);

        Assert.That("fixme", Is.EqualTo("fixme"));
    }
}
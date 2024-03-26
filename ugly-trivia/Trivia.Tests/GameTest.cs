
using NUnit.Framework;

namespace Trivia.Tests;

public class GameTest
{
    [Test]
    public void Should_Not_Pass()
    {
        Assert.That(false, Is.True);
    }
}
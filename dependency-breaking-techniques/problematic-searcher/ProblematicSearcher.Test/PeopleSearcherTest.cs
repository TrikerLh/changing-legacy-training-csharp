namespace ProblematicSearcher.Test;

public class PeopleSearcherTest
{
    [Test]
    public void Test1()
    {
        PeopleSearcher peopleSearcher = new PeopleSearcher();

        var persons = peopleSearcher.Search("Pedro");

        Assert.That(persons.Count(), Is.EqualTo(2));
    }
}
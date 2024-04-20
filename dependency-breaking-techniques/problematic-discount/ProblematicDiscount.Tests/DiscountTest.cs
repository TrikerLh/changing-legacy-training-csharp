using NUnit.Framework;

namespace ProblematicDiscount.Tests;

public class DiscountTest
{
    [Test]
    public void Discount_On_Crazy_Sales_Day()
    {
        var discount = new Discount();

        var total = discount.DiscountFor(new Money(100.0m));

        Assert.That(total, Is.EqualTo(new Money(85.0m)));
    }
}
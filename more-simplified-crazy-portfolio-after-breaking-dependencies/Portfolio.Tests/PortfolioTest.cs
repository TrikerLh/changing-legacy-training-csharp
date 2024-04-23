using NUnit.Framework;
using static Portfolio.Tests.helpers.AssetsFileLinesBuilder;
using static Portfolio.Tests.helpers.TestingPortfolioBuilder;

namespace Portfolio.Tests;

public class PortfolioTest
{
    [Test]
    public void regular_asset_value_decreases_by_2_before_now()
    {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("Some Regular Asset").FromDate("2024/01/15").WithValue(100))
            .OnDate("2025/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("98"));
    }

    [Test]
    public void french_wine_asset_value_increases_by_2_before_now_when_value_is_less_than_200() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("French Wine").FromDate("2024/01/15").WithValue(100))
            .OnDate("2025/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("102"));
    }

    [Test]
    public void french_wine_asset_value_not_change_before_now_when_value_is_greather_than_200() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("French Wine").FromDate("2024/01/15").WithValue(200))
            .OnDate("2025/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("200"));
    }

    [Test]
    public void lottery_prediction_asset_is_before_now_value_is_zero() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("Lottery Prediction").FromDate("2024/01/15").WithValue(200))
            .OnDate("2025/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("0"));
    }

    [Test]
    public void unicorn_asset_is_before_now_value_is_priceless() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("Unicorn").FromDate("2024/01/15").WithValue(200))
            .OnDate("2025/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("Portfolio is priceless because it got a unicorn!!!!!"));
    }


    [Test]
    public void regular_asset_value_decreases_by_1_after_now() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("Some Regular Asset").FromDate("2024/01/15").WithValue(100))
            .OnDate("2024/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("99"));
    }
    [Test]
    public void french_wine_asset_value_increases_by_1_after_now_when_is_less_than_200() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("French Wine").FromDate("2024/01/15").WithValue(100))
            .OnDate("2024/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("101"));
    }

    [Test]
    public void french_wine_asset_value_not_change_after_now_when_is_greater_than_200() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("French Wine").FromDate("2024/01/15").WithValue(200))
            .OnDate("2024/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("200"));
    }

    [Test]
    public void unicorn_asset_is_after_now_value_is_priceless() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("Unicorn").FromDate("2024/01/15").WithValue(200))
            .OnDate("2024/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("Portfolio is priceless because it got a unicorn!!!!!"));
    }

    [Test]
    public void unicorn_asset_is_after_now_and_value_is_negative_value_is_priceless() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("Unicorn").FromDate("2024/01/15").WithValue(0))
            .OnDate("2024/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("Portfolio is priceless because it got a unicorn!!!!!"));
    }


}

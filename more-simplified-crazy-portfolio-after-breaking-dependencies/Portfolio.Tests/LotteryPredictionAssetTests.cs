using NUnit.Framework;
using static Portfolio.Tests.helpers.AssetsFileLinesBuilder;
using static Portfolio.Tests.helpers.TestingPortfolioBuilder;

namespace Portfolio.Tests;

public class LotteryPredictionAssetTests
{
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
    public void lottery_prediction_asset_is_more_11_days_after_now_and_value_is_less_than_800() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("Lottery Prediction").FromDate("2024/01/15").WithValue(200))
            .OnDate("2024/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("201"));
    }

    [Test]
    public void lottery_prediction_asset_is_less_than_11_days_and_greater_than_6_after_now_and_value_is_less_than_800() {
        var portfolio = APortFolio()
            .With(AnAsset().DescribedAs("Lottery Prediction").FromDate("2024/01/10").WithValue(200))
            .OnDate("2024/01/01")
            .Build();

        portfolio.ComputePortfolioValue();

        Assert.That(portfolio._messages[0], Is.EqualTo("202"));
    }
}

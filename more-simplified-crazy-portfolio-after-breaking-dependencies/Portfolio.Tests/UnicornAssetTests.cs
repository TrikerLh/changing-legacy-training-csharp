using NUnit.Framework;
using static Portfolio.Tests.helpers.AssetsFileLinesBuilder;
using static Portfolio.Tests.helpers.TestingPortfolioBuilder;

namespace Portfolio.Tests {
    public class UnicornAssetTests {
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
        public void unicorn_asset_is_after_now_value_is_priceless() {
            var portfolio = APortFolio()
                .With(AnAsset().DescribedAs("Unicorn").FromDate("2024/01/15").WithValue(200))
                .OnDate("2024/01/01")
                .Build();

            portfolio.ComputePortfolioValue();

            Assert.That(portfolio._messages[0], Is.EqualTo("Portfolio is priceless because it got a unicorn!!!!!"));
        }
    }
}

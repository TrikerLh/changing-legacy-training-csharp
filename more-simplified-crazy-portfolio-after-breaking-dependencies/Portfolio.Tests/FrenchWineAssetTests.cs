using NUnit.Framework;
using static Portfolio.Tests.helpers.AssetsFileLinesBuilder;
using static Portfolio.Tests.helpers.TestingPortfolioBuilder;

namespace Portfolio.Tests {
    public class FrenchWineAssetTests {
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
    }
}

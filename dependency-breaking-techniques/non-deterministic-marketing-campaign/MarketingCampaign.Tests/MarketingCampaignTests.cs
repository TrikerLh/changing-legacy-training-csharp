using NUnit.Framework;

namespace MarketingCampaign.Tests;

public class MarketingCampaignTests
{
    [Test]
    public void Would_I_Always_Pass()
    {
        var campaign = new MarketingCampaign();

        var isCrazySalesDay = campaign.IsCrazySalesDay();

        Assert.That(isCrazySalesDay, Is.False);
    }
        
    [Test]
    public void Fix_Me()
    {
        var campaign = new MarketingCampaign();

        var isCrazySalesDay = campaign.IsActive();

        Assert.That(isCrazySalesDay, Is.True);
    }
}
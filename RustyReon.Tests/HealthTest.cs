namespace RustyReon.Tests;

public class HealthTest
{
    [Fact]
    public void Test1()
    {
        Assert.True(new Health().Test_Health_OK());
    }
}

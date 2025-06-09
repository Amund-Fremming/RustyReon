using RustyReon.Core;
using RustyReon.Exceptions;

namespace RustyReon.Tests.Core;

public class OptionTests
{
    [Fact]
    public void Unwrap_Empty_Option_Throws()
    {
        Option<int> option = Option.None;
        Assert.Throws<EmptyOptionException>(() => option.Unwrap());
    }
    
    [Fact]
    public void Unwrap_Option_Successful()
    {
        Option<int> option = 10;
        Assert.Equal(10, option.Unwrap());
    }
}
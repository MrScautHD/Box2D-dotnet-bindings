namespace UnitTests;

public class Box2DVersionTest
{
    [Fact]
    public void CheckVersion()
    {
        string? error = null;
        Box2D.Box2D.SetAssertFunction((condition, name, number) =>
        {
            error = condition;
            return 0;
        });
        
        var version = Box2D.Box2D.GetVersion();
        string versionString = $"v{version.Major}.{version.Minor}.{version.Revision}";
        Assert.Equal("v3.0.0", versionString);
        
        if (error is not null) Assert.Fail(error);
    }
    
}
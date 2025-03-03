namespace UnitTests;

public class Box2DVersionTest
{
    [Fact]
    public void CheckVersion()
    {
        var version = Box2D.Box2D.GetVersion();
        string versionString = $"v{version.Major}.{version.Minor}.{version.Revision}";
        Assert.Equal("v3.0.0", versionString);
    }
    
}
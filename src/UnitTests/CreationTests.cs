using Box2D;

namespace UnitTests;

public class CreationTests
{
    [Fact]
    public void CreateWorldFromDefault()
    {
        string? error = null;
        Box2D.Box2D.SetAssertFunction((condition, name, number) =>
        {
            error = condition;
            return 0;
        });
        
        WorldDef def = WorldDef.Default;
        World world = World.CreateWorld(def);
        if (error is not null) Assert.Fail(error);
    }

    [Fact]
    public void CreateWorldDefFromNew()
    {
        string? error = null;
        Box2D.Box2D.SetAssertFunction((condition, name, number) =>
        {
            error = condition;
            return 0;
        });
        
        WorldDef def = new WorldDef();
        WorldDef fromDefault = WorldDef.Default;
        Assert.Equal(def.MaximumLinearSpeed, fromDefault.MaximumLinearSpeed);
        if (error is not null) Assert.Fail(error);
    }

    [Fact]
    void CreateTwoJointedBodies()
    {
        string? error = null;
        Box2D.Box2D.SetAssertFunction((condition, name, number) =>
        {
            error = condition;
            return 0;
        });
        
        WorldDef worldDf = new WorldDef();
        World world = World.CreateWorld(worldDf);

        BodyDef bodyDef = new BodyDef();
        bodyDef.Type = BodyType.Dynamic;
        bodyDef.Position = (-10f, 0f);
        Body bodyA = world.CreateBody(bodyDef);

        bodyDef.Position = (10f, 0f);
        Body bodyB = world.CreateBody(bodyDef);

        DistanceJointDef jointDef = new DistanceJointDef();
        jointDef.BodyA = bodyA;
        jointDef.BodyB = bodyB;
        jointDef.LocalAnchorA = (0f, 0f);
        jointDef.LocalAnchorB = (0f, 0f);
        
        Joint joint = world.CreateJoint(jointDef);
        
        if (error is not null) Assert.Fail(error);
    }
}

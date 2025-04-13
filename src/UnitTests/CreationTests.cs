using Box2D;
using System.Numerics;

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
        bodyDef.Position = new(-10f, 0f);
        Body bodyA = world.CreateBody(bodyDef);

        bodyDef.Position = new(10f, 0f);
        Body bodyB = world.CreateBody(bodyDef);

        DistanceJointDef jointDef = new DistanceJointDef();
        jointDef.BodyA = bodyA;
        jointDef.BodyB = bodyB;
        jointDef.LocalAnchorA = new(0f, 0f);
        jointDef.LocalAnchorB = new(0f, 0f);
        
        Joint joint = world.CreateJoint(jointDef);
        
        if (error is not null) Assert.Fail(error);
    }
    
    [Fact]
    void CreateChainShape()
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
        bodyDef.Type = BodyType.Static;
        bodyDef.Position = new(0f, 0f);
        Body bodyA = world.CreateBody(bodyDef);

        Vector2[] vertices =
        {
            new(-5f, -10),
            new(-3.2f, 10),
            new(-3.2f, 0),
            new(3.2f, 0),
            new(3.2f, 10),
            new(5f, -10),
            new(-5f, -10)
        };

        ChainDef chainDef = new ChainDef()
            {
                Points = vertices,
                IsLoop = true
            };
        
        ChainShape chainShape = bodyA.CreateChain(chainDef);

        // Materials is set by Box2D, and so it has a pointer that we didn't create.
        // We should have a check in the Materials property and the finalizer to
        // make sure the one we're trying to Free is our own. If this fails, then
        // that would be the first place to look.
        chainDef.Materials = [];
        
        if (error is not null) Assert.Fail(error);
    }
}

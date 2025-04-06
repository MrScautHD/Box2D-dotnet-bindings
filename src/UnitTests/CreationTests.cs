using Box2D;

namespace UnitTests;

public class CreationTests
{
    [Fact]
    public void CreateWorldFromDefault()
    {
        Box2D.Box2D.SetAssertFunction((condition, name, number) =>
        {
            Assert.Fail(condition);
            return 0;
        });
        
        WorldDef def = WorldDef.Default;
        World world = World.CreateWorld(def);
    }

    [Fact]
    public void CreateWorldDefFromNew()
    {
        Box2D.Box2D.SetAssertFunction((condition, name, number) =>
        {
            Assert.Fail(condition);
            return 0;
        });
        
        WorldDef def = new WorldDef();
        WorldDef fromDefault = WorldDef.Default;
        Assert.Equal(def.MaximumLinearSpeed, fromDefault.MaximumLinearSpeed);
    }

    [Fact]
    void CreateTwoJointedBodies()
    {
        Box2D.Box2D.SetAssertFunction((condition, name, number) =>
        {
            Assert.Fail(condition);
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

        if(jointDef._internal.internalValue!=1152023)
            Assert.Fail("JointDef cookie is wrong");
        
        Joint joint = world.CreateJoint(jointDef);
    }
}

using Xunit;
using System;

public class RobotNameTest
{
    [Fact]
    public void Robot_has_a_name()
    {
        var robot = new Robot();
        Assert.Matches(@"[A-Z]{2}\d{3}", robot.Name);
    }

    [Fact]
    public void Name_is_the_same_each_time()
    {
        var robot = new Robot();
        Assert.Equal(robot.Name, robot.Name);
    }

    [Fact]
    public void Different_robots_have_different_names()
    {
        var robot = new Robot();
        var robot2 = new Robot();
        Assert.NotEqual(robot2.Name, robot.Name);
    }

    [Fact]
    public void Can_reset_the_name()
    {
        var robot = new Robot();
        var originalName = robot.Name;
        robot.Reset();
        Assert.NotEqual(originalName, robot.Name);
    }
}
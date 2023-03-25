using NUnit.Framework;

public class EditTester
{
    private int[] testArray = new int[] { 1, 2, 3 };

    // A Test behaves as an ordinary method
    [Test]
    public void Test1()
    {
        // Use the Assert class to test conditions
        //Assert.Pass();
        Assert.Fail();
    }

    [Test]
    public void Test2()
    {
        Assert.GreaterOrEqual(testArray.Length, 1);
    }
}
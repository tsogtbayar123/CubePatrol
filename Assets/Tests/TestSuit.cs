using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuit
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestSuitSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestPauseFalse()
    {

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        GameHandler handler = GameHandler.Instance();
        Assert.False(handler.bPause);

        yield return null;
    }

}

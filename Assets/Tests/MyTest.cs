using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyTest
{

    Player plaerPef = Resources.Load<Player>("Player");

    // A Test behaves as an ordinary method
    [Test]
    public void TestPlayerExists()
    {
        var player = GameObject.Instantiate(plaerPef);
        Assert.IsNotNull(player);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestPlayerMoved()
    {
        var player = GameObject.Instantiate(plaerPef);
        Assert.IsNotNull(player);
        var oldpos = player.transform.position;
        player.Move(1);

        yield return new WaitForSeconds(0.5f);
        Assert.IsTrue(player.transform.position != oldpos);
    }
}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BowlingGameShould
{
    public BowlingGame bowlingGame;

    [SetUp]
    public void config() 
    {
        bowlingGame = new BowlingGame();

    }

    [Test]
    public void HaveTenTurns()
    {
        //When
        int turns = bowlingGame.getTurns();

        //Then
        Assert.AreEqual(10, turns);
    }


}

public class BowlingGame 
{
    int[] cantidadBolosTirados = new int[10];
    // int[] isStrike;

    public int getTurns() 
    {
        return cantidadBolosTirados.Length;
    }

}

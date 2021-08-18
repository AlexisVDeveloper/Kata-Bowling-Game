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
        
        int[] pineAmount = { 10, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        bowlingGame.setTotalPineAmount(pineAmount);
    }

    [Test]
    public void HaveTenTurns()
    {
        //When
        int turns = bowlingGame.getTurns();

        //Then
        Assert.AreEqual(10, turns);
    }

    [Test]
    public void HaveTenMaxPinePerTurn()
    {

        //Given
        bool exceedsMaxPineAmount = false;

        //When
        foreach (int i in bowlingGame.getTotalPineAmount())
        {
            if (i > 10) exceedsMaxPineAmount = true;
        }

        //Then
        Assert.AreEqual(false, exceedsMaxPineAmount);
    }


}

public class BowlingGame 
{
    int[] totalPineAmount = new int[10];
    // int[] isStrike;

    public int getTurns() 
    {
        return totalPineAmount.Length;
    }

    public int[] getTotalPineAmount() 
    {
        return totalPineAmount;
    }
    public void setTotalPineAmount(int[] pineAmount)
    {
        this.totalPineAmount = pineAmount;
    }

}

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
        
        int[,] pineAmount = { { 3, 4 }, { 10, 0 }, { 5, 0 }, { 2, 0 }, { 3, 3 }, { 3, 4 }, { 10, 0 }, { 5, 5 }, { 2, 0 }, { 3, 3 } };

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
        Assert.IsFalse(exceedsMaxPineAmount);
    }

    [Test]
    public void ScoreOnTurnEqualsSumOfPines()
    {

        //When
        int turnScore = bowlingGame.sumTurnPines(0);

        //Then
        Assert.AreEqual(7, turnScore);
    }

}

public class BowlingGame 
{
    int[,] totalPineAmount = new int[10,2];
    // int[] isStrike;

    public int getTurns() 
    {
        return totalPineAmount.GetLength(0);
    }

    public int[,] getTotalPineAmount() 
    {
        return totalPineAmount;
    }
    public void setTotalPineAmount(int[,] pineAmount)
    {
        this.totalPineAmount = pineAmount;
    }
    public int sumTurnPines(int turn)
    {
        return totalPineAmount[turn, 0] + totalPineAmount[turn,1];
    }
}

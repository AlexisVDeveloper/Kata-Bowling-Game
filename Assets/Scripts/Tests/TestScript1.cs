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

        List<Turn> turns = new List<Turn>(10);

        turns.Add(new Turn(3, 7));
        turns.Add(new Turn(10, 0));
        turns.Add(new Turn(2, 0));
        turns.Add(new Turn(3, 3));
        turns.Add(new Turn(3, 4));
        turns.Add(new Turn(10, 0));
        turns.Add(new Turn(5, 5));
        turns.Add(new Turn(2, 0));
        turns.Add(new Turn(3, 3));
        turns.Add(new Turn(3, 2));

        bowlingGame.setTotalPineAmount(turns);
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
        foreach (Turn turn in bowlingGame.getTotalPineAmount())
        {
            if (turn.getTurnScore() > 10) exceedsMaxPineAmount = true;
        }

        //Then
        Assert.IsFalse(exceedsMaxPineAmount);
    }

    [Test]
    public void ScoreOnTurnEqualsSumOfPines()
    {

        int turnScore = bowlingGame.getTotalPineAmount()[0].getThrowedPines()[0] + bowlingGame.getTotalPineAmount()[0].getThrowedPines()[1];

        //Then
        Assert.AreEqual(10, turnScore);
    }

    [Test]
    public void ScoreAllPinesWithoutStrikes()
    {
        //Then
        Assert.AreEqual(68, bowlingGame.sumAllPines());
    }

    [Test]
    public void DetectSpares()
    {
        bool isSpare = bowlingGame.getTotalPineAmount()[0].isSpare();

        //Then
        Assert.IsTrue(isSpare);
    }
    [Test]
    public void DetectStrikes()
    {
        bool isStrike = bowlingGame.getTotalPineAmount()[1].isStrike();

        //Then
        Assert.IsTrue(isStrike);
    }
    [Test]
    public void GetTotalScore()
    {
        int totalScore = bowlingGame.getTotalScore();
        
        //Then
        Assert.AreEqual(80, totalScore);
    }

}

public class BowlingGame 
{
    Turn[] totalPineAmount = new Turn[10];
    

    public int getTurns() 
    {
        return totalPineAmount.GetLength(0);
    }

    public Turn[] getTotalPineAmount() 
    {
        return totalPineAmount;
    }
    public void setTotalPineAmount(List<Turn> turns)
    {
        this.totalPineAmount = turns.ToArray();
    }
 
    public int getTotalScore()
    {
        int totalScore = 0;
        totalScore =+ this.sumAllPines();
        totalScore = +this.sumSparePoints();
        totalScore = +this.sumStrikePoints();

        return totalScore;
    }
    public int sumAllPines()
    {
        int result = 0;

        for (int i = 0; i < totalPineAmount.Length; i++)
        {
            result += totalPineAmount[i].getTurnScore();
        }
        
        return result;
    }
    public int sumSparePoints() 
    {
        int result = 0;
        for (int i = 0; i < totalPineAmount.Length; i++)
        {
            int nextIndex = i + 1;
            if (totalPineAmount[i].isSpare() && nextIndex < totalPineAmount.Length)
            {
                result += totalPineAmount[nextIndex].getTurnScore();
            }
        }
        return result;
    }
    public int sumStrikePoints()
    {
        int result = 0;
        for (int i = 0; i < totalPineAmount.Length; i++)
        {
            int next2Index = i + 2;
            if (totalPineAmount[i].isStrike() && next2Index < totalPineAmount.Length)
            {
                result += totalPineAmount[next2Index -1].getTurnScore();
                result += totalPineAmount[next2Index].getTurnScore();

            }
        }
        return result;
    }
}
public class Turn
{
    bool spare = false;
    bool strike = false;
    int[] throwedPines = new int [2];

    public Turn(int firstShot, int secondShot) 
    {   
        throwedPines[0] = firstShot;
        throwedPines[1] = secondShot;

        detectSpare();
        detectStrike();
    }
    public int[] getThrowedPines() 
    {
        return throwedPines;
    }
    public void setThrowedPines(int[] throwedPines)
    {
        this.throwedPines = throwedPines;
    }
    public int getTurnScore()
    {
        return throwedPines[0] + throwedPines[1];
    }
    public bool isSpare() 
    {
        return spare;
    }
    public bool isStrike()
    {
        return strike;
    }
    private void detectSpare() 
    {
        if (this.getTurnScore() == 10 && throwedPines[1] != 0)
        {
            spare = true;
        }    
    }
    private void detectStrike()
    {
        if (this.getTurnScore() == 10 && throwedPines[1] == 0)
        {
            strike = true;
        }
    }

}

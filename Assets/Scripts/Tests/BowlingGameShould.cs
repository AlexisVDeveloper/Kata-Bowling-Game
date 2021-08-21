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

        turns.Add(new Turn(3, 7));   //10
        turns.Add(new Turn(10, 0));  //30
        turns.Add(new Turn(2, 0));   //34
        turns.Add(new Turn(3, 3));   //40
        turns.Add(new Turn(3, 4));   //47
        turns.Add(new Turn(10, 0));  //57
        turns.Add(new Turn(5, 5));   //77
        turns.Add(new Turn(2, 3));   //84
        turns.Add(new Turn(3, 3));   //90
        turns.Add(new Turn(3, 2));   //95

        int bonusShotPines = 2;

        bowlingGame.setTotalPineAmount(turns.ToArray(), bonusShotPines);
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
        Assert.AreEqual(71, bowlingGame.sumAllPines());
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
        Assert.AreEqual(99, totalScore);
    }

}


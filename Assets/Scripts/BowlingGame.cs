using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingGame
{
    Turn[] totalPineAmount = new Turn[10];
    int bonusShot = 0;

    public int getTurns()
    {
        return totalPineAmount.GetLength(0);
    }

    public Turn[] getTotalPineAmount()
    {
        return totalPineAmount;
    }
    public void setTotalPineAmount(Turn [] turns, int bonusShot = 0)
    {
        this.totalPineAmount = turns;
        this.bonusShot = bonusShot;
    }

    public int getTotalScore()
    {
        int totalScore = 0;
        totalScore += this.sumAllPines();
        totalScore += this.sumSparePoints();
        totalScore += this.sumStrikePoints();
        totalScore += bonusShot * 2;

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
                result += totalPineAmount[nextIndex].getThrowedPines()[0];
            }
        }
        return result;
    }
    public int sumStrikePoints()
    {
        int result = 0;
        for (int i = 0; i < totalPineAmount.Length; i++)
        {
            int nextIndex = i + 1;
            if (totalPineAmount[i].isStrike() && nextIndex < totalPineAmount.Length)
            {
                result += totalPineAmount[nextIndex].getTurnScore();
            }
        }
        return result;
    }
}
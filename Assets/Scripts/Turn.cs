using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn
{
    bool spare = false;
    bool strike = false;
    int[] throwedPines = new int[2];

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

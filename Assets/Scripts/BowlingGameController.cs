using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingGameController : MonoBehaviour
{
    [SerializeField]
    private Text txtTurno, txtScore;
    [SerializeField]
    private InputField input;
    [SerializeField]
    private Button btnTirar;

    private BowlingGame bowlingGame;
    private bool isFirstShot = true;
    private int firstShotAux = 0;
    private int bonusShot = 0;

    private List<Turn> gameTurns;

    void Start()
    {
        bowlingGame = new BowlingGame();
        gameTurns = new List<Turn>();
    }

    public void Shoot()
    {
        int currenShot = Convert.ToInt32(input.text);
        
        if (isFirstShot)
        {
            if (currenShot == 10 && gameTurns.Count < 10)
            {
                CreateNewTurn(currenShot, 0);
                isFirstShot = true;
            }
            else 
            {
                firstShotAux = currenShot;
                isFirstShot = false;
            }
        }
        else // Si es el segundo tiro
        {
            isFirstShot = true;
            CreateNewTurn(firstShotAux, currenShot);
        }

        if (gameTurns.Count >= 10) //temporal
            FinalizeGame();
        else 
        {
            string turnNumberAux = isFirstShot ? "1" : "2";
            txtTurno.text = $"Turno: {gameTurns.Count + 1} Tiro: {turnNumberAux}";
        }
    }

    private void FinalizeGame() 
    {
        bowlingGame.setTotalPineAmount(gameTurns.ToArray(), bonusShot);
        txtScore.text = bowlingGame.getTotalScore().ToString();
        btnTirar.enabled = false;
    }

    private void CreateNewTurn(int firstShot, int secondShot)
    {
        gameTurns.Add(new Turn(firstShot, secondShot));  
    } 
}

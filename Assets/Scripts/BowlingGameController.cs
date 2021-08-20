using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingGameController : MonoBehaviour
{
    public Text txtTurno, txtScore;
    public InputField input;
    public Button btnTirar;

    private BowlingGame bowlingGame;
    private bool isFirstShot = true;
    private int firstShotAux = 0;
    private int bonusShot = 0;

    private List<Turn> gameTurns = new List<Turn>();

    // Start is called before the first frame update
    void Start()
    {
        bowlingGame = new BowlingGame();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Shoot()
    {


        int currenShot = Convert.ToInt32(input.text);
        
        Turn turn;
        if (isFirstShot)
        {
            if (currenShot == 10)
            {
                turn = new Turn(10, 0);
                gameTurns.Add(turn);
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
            turn = new Turn(firstShotAux, currenShot);
            gameTurns.Add(turn);
            isFirstShot = true;
            if (gameTurns.Count == 9) 
            {
                
            }
        }
        string turnNumberAux = isFirstShot ? "1" : "2";
        txtTurno.text = $"Turno: {gameTurns.Count + 1} Tiro: {turnNumberAux}";

        if (gameTurns.Count == 9 && !isFirstShot) //temporal
        {
            endGame();
        }
    }

    private void endGame() {

        bowlingGame.setTotalPineAmount(gameTurns.ToArray(), bonusShot);

        txtScore.text = bowlingGame.getTotalScore().ToString();

        btnTirar.enabled = false;

    }

    private void createTurn(int firstShot, int secondShot)
    {
        
    } 
    
}

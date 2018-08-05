using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Board mBoard;
    public Text mCursor;
    public GameObject mWinner;

    private bool mXTurn = true;
    private int mTurnCount = 0;

    void Awake()
    {
        mBoard.Build(this);

        mCursor.text = GetTurnCharacter();

    }

    public void Switch()
    {
        mTurnCount++;

        bool hasWinner = mBoard.CheckForWinner();
        if (hasWinner || mTurnCount == 9) // if there's a winner or count reaches 9, we don't want to have a winner
        {
            // End Game
            StartCoroutine(EndGame(hasWinner));


            return;
        }

        mXTurn = !mXTurn; //keeping track if it's X turn or Y turn

        mCursor.text = GetTurnCharacter();
    }

    public string GetTurnCharacter()
    {
        if(mXTurn) //if mXTurn is true
        {
            return "X";
        }

        else
        {
            return "0";
        }
    }

    private IEnumerator EndGame(bool hasWinner)
    {
        Text winnerLabel = mWinner.GetComponentInChildren<Text>();

        if(hasWinner)
        {
            winnerLabel.text = GetTurnCharacter() + " " + "Won!";
        }

        else
        {
            winnerLabel.text = "Draw!";
        }

        mWinner.SetActive(true);

        WaitForSeconds wait = new WaitForSeconds(5.0f);
        yield return wait;

        mBoard.Reset();
        mTurnCount = 0;

        mWinner.SetActive(false);
    }

}

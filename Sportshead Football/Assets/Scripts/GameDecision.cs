using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDecision : MonoBehaviour
{
    [SerializeField] GameObject secondPosP1;
    [SerializeField] GameObject secondPosP2;
    [SerializeField] GameObject firstPosP1;
    [SerializeField] GameObject firstPosP2;

    GameStatus gameStatus;

    void Start() {
        SelectWinner(FindObjectOfType<GameStatus>().GetPlayerScore(1), FindObjectOfType<GameStatus>().GetPlayerScore(2));
    }

    public void SelectWinner(int player1Score, int player2Score) {
        if (player2Score == 7) {
            firstPosP1.SetActive(true);
            secondPosP2.SetActive(true);
        }
        else {
            firstPosP2.SetActive(true);
            secondPosP1.SetActive(true);
        }
    }
}

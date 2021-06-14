using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1Score;
    [SerializeField] TextMeshProUGUI player2Score;
    [SerializeField] TextMeshProUGUI player1Team;
    [SerializeField] TextMeshProUGUI player2Team;
    [SerializeField] TextMeshProUGUI secondsCounter;

    GameStatus gameStatus;
    // Start is called before the first frame update
    void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        player1Team.text = "Pakistan";
        player2Team.text = "India";
        //InitializeCounter();
        StartCoroutine(WaitRoutine());
    }

    IEnumerator WaitRoutine() {
        secondsCounter.gameObject.SetActive(true);
        var seconds = gameStatus.secondsCounter;
        while (seconds > 0) {
            secondsCounter.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds--;
        }
        secondsCounter.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    private void UpdateScore() {
        player1Score.text = gameStatus.GetPlayerScore(1).ToString();
        player2Score.text = gameStatus.GetPlayerScore(2).ToString();
        if (gameStatus.isGoalScored) {
            gameStatus.isGoalScored = false;
            StartCoroutine(WaitRoutine());
        }
    }
}

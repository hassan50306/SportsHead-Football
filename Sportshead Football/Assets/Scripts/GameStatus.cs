using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;
    public bool enablePlayerInput = false;
    public float secondsCounter = 3f;
    public bool isGoalScored = false;

    [SerializeField] Player player1;
    [SerializeField] Player player2;
    [SerializeField] Football football;
    [SerializeField] AudioClip[] applauseClips;

    void Awake() {
        SetUpSingelton();
    }

    void Start() {
        StartGame();
    }

    private void SetUpSingelton() {
        if (FindObjectsOfType<GameStatus>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void StartGame() {
        enablePlayerInput = false;
        player1.transform.position = new Vector2(5.42f, -6.214136f);
        player2.transform.position = new Vector2(-5.35f, -6.214136f);
        football.transform.position = new Vector2(0f, 2f);
        football.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        StartCoroutine(WaitRoutine(secondsCounter));
    }

    IEnumerator WaitRoutine(float seconds) {
        yield return new WaitForSeconds(seconds);
        enablePlayerInput = true;
        football.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        football.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5f, 5f), 0f);
    }

    public int GetPlayerScore(int playerNo) {
        if (playerNo == 1)
            return player1Score;
        else
            return player2Score;
    }

    public void SetPlayerScore(int playerNo) {
        if (playerNo == 1)
            player1Score++;
        if (playerNo != 1)
            player2Score++;
        isGoalScored = true;
        PlayApplauseClip();
        StartCoroutine(WaitBeforeStart(0.2f));
        if (player1Score == 7 || player2Score == 7) {
            FindObjectOfType<Level>().LoadGameOverScene();
            //FindObjectOfType<GameDecision>().SelectWinner(player1Score, player2Score);
        }
    }

    IEnumerator WaitBeforeStart(float seconds) {
        yield return new WaitForSeconds(seconds);
        StartGame();
    }

    private void PlayApplauseClip() {
        if (isGoalScored) {
            var i = Random.Range(0, applauseClips.Length);
            AudioSource.PlayClipAtPoint(applauseClips[i], Camera.main.transform.position);
        }
    }
}

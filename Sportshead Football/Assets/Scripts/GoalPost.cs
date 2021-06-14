using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    // Start is called before the first frame update
    GameStatus gameStatus;
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Football") {
            if (gameObject.tag == "Post1") {
                Debug.Log("hit1");
                gameStatus.SetPlayerScore(2);
            } 
            if (gameObject.tag == "Post2") {
                gameStatus.SetPlayerScore(1);
            }
        }
    }
}

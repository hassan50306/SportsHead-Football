using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public bool isPaused = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu() {
        isPaused = !isPaused;
        if (isPaused) {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        if (!isPaused) {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }
}

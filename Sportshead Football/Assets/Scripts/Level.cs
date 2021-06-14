using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadStartMenuScene() {
        SceneManager.LoadScene(0);
    }

    public void LoadMainGameScene() {
        SceneManager.LoadScene(3);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadInstructions() {
        SceneManager.LoadScene(1);
    }

    public void LoadGameOverScene() {
        SceneManager.LoadScene(2);
    }
}

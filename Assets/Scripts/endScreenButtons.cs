using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScreenButtons : MonoBehaviour
{
    [SerializeField] bool replayGame = false;
    [SerializeField] bool endGame = false;
    [SerializeField] bool pauseGame = false;
    [SerializeField] GameObject pauseMenuUI;

    public void endScreen()
    {
        if (replayGame)
        {
            gameManager.instance.RestartGame();
        }
        if(endGame)
        {
            gameManager.instance.QuitGame();
        }
        if (pauseGame)
        {
            gameManager.instance.isPaused = !gameManager.instance.isPaused;
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        }
    }

}

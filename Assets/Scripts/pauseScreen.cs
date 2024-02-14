using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScreen : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] GameObject pauseMenuUI;
    private void Update()
    {
        if (!gameManager.instance.IsFirstScene() &&  Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(pauseMenuUI.activeSelf);
            isPaused = !isPaused;
            gameManager.instance.isPaused = isPaused;
            pauseMenuUI.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }
    }
}

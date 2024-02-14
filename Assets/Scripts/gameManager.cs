using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public int score = 0;
    public int health = 3;
    public int scoreInCurrentScene = 0;
    public float timer;
    public bool isPaused = false;
    [SerializeField] public AudioSource themeSong;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            scoreInCurrentScene = 0;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            Application.targetFrameRate = 60;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!IsLastScene() && !IsFirstScene())
        {
            timer += Time.deltaTime;
        }
        
        if (!isPaused && !IsFirstScene() && !IsLastScene())
        {
            if(Input.GetKey(KeyCode.R))
            {
                RestartGame();
                SceneManager.LoadScene(1);
            }
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset the scoreInCurrentScene when a new scene is loaded
        scoreInCurrentScene = 0;
    }
    public void UpdateScore()
    {
        score++;
        scoreInCurrentScene++;
    }

    public void UpdateHealth()
    {
        health--;
    }

    private bool IsLastScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int lastScene = SceneManager.sceneCountInBuildSettings - 1;

        return currentScene == lastScene;
    }

    public bool IsFirstScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int firstScene = 0;
        return currentScene == firstScene;
    }

    public void StartThemeMusic()
    {
        themeSong.PlayOneShot(themeSong.clip);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        health = 3;
        score = 0;
        timer = 0;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}

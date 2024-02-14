using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
        gameManager.instance.StartThemeMusic();
    }
}

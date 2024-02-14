using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class obstacleManagement : MonoBehaviour
{
    private Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles")) {
            Debug.Log("died");
            gameManager.instance.health--;
            gameManager.instance.score -= gameManager.instance.scoreInCurrentScene;
            SceneManager.LoadScene(scene.buildIndex);
            if (gameManager.instance.health == 0)
            {
                gameManager.instance.RestartGame();
            }
        }
    }


}

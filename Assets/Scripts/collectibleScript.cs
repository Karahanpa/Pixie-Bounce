using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class collectibleScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private AudioSource scoreAudioSource;
    private int score = gameManager.instance.score;

    private void Awake()
    {
        scoreAudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectibles"))
        {
            score++;
            UpdateScore();
            scoreAudioSource.Play();
            Destroy(collision.gameObject);
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }


}

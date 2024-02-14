using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreTrigger : MonoBehaviour
{
    [SerializeField] AudioSource scoreSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectibles"))
        {
            gameManager.instance.UpdateScore();
            Destroy(collision.gameObject);
            scoreSound.Play();
        }
    }
}

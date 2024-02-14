using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public void UpdateScore()
    {
        gameManager.instance.UpdateScore();
    }
}

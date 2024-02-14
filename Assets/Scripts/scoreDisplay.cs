using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class scoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score:" + gameManager.instance.score + "/8";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timeDisplay : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void Update()
    {
        UpdateTimeText();
    }
    private void UpdateTimeText()
    {
        float timeValue = gameManager.instance.timer;
        string formattedTime = FormatTime(timeValue);
        timeText.text = formattedTime;
    }

    private string FormatTime(float timeValue)
    {
        int minutes = Mathf.FloorToInt(timeValue / 60f);
        int seconds = Mathf.FloorToInt(timeValue % 60f);
        int milliseconds = Mathf.FloorToInt(timeValue * 1000) % 1000;
        //float roundedMilliseconds = Mathf.Round(timeValue * 1000f) / 1000f;

        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }

}

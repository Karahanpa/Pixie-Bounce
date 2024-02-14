using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthManager : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image health1, health2, health3;
    private void Update()
    {
        UpdateHealthDisplay();
    }
    private void UpdateHealthDisplay()
    {
        switch (gameManager.instance.health)
        {
            case 3:
                health1.enabled = true;
                health2.enabled = true;
                health3.enabled = true;
                break;
            case 2:
                health1.enabled = false;
                health2.enabled = true;
                health3.enabled = true;
                break;
            case 1:
                health1.enabled = false;
                health2.enabled = false;
                health3.enabled = true;
                break;
            default:
                break;
        }
    }
}



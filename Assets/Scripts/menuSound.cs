using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class menuSound : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(PlayButtonClickSound);
    }

    public void PlayButtonClickSound()
    {
        clickSound.PlayOneShot(clickSound.clip);
    }
}
    

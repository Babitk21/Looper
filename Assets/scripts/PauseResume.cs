using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    [SerializeField] GameObject pauseButton, resumeButton;
    public void OnPause()
    {
        Time.timeScale = 0.0f;
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void OnResume()
    {
        Time.timeScale = 1.0f;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }
}

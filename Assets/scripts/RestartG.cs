using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartG : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
